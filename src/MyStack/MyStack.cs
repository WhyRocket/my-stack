using MyStack.Exceptions;

namespace MyStack;

public class MyStack<T>
{
    private const int _maxCapacity = 500;

    private readonly int _capacity;
    private readonly T[] _elements;

    public int Count { get; private set; }

    public int Capacity
    {
        get { return _capacity; }
        init
        {
            if (value > 0 && value <= _maxCapacity)
            {
                _capacity = value;
            }
            else
            {
                throw new CapacityExceededMyStackException(_maxCapacity);
            }
        }
    }

    public event Action<T>? OnPush;

    public event Action<T>? OnPop;

    public event Action? OnEmpty;

    public MyStack(int capacity)
    {
        Capacity = capacity;
        _elements = new T[Capacity];
    }

    // Данный метод добавляет элемент в стэк.
    public void Push(T element)
    {
        if (Count < Capacity)
        {
            _elements[Count] = element;
            Count++;

            if (OnPush is not null)
            {
                OnPush(element);
            }
        }
        else
        {
            throw new CapacityExceededMyStackException(_maxCapacity);
        }
    }

    // Данный метод удаляет элемент из стэка.
    public void Pop()
    {
        if (Count > 0)
        {
            if (OnPop is not null)
            {
                OnPop(_elements[Count - 1]);
            }

            Count--;

            if (Count == 0 && OnEmpty is not null)
            {
                OnEmpty();
            }
        }
        else
        {
            throw new EmptyMyStackException();
        }
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new EmptyMyStackException();
        }

        return _elements[Count - 1];
    }
}