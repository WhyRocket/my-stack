namespace MyStack;

public class MyStack<T>
{
    private readonly int _capacity;
    private readonly T[] _elements;

    public int Count { get; private set; }

    public int Capacity
    {
        get { return _capacity; }
        init
        {
            if (value > 0 && value <= 500)
            {
                _capacity = value;
            }
            else
            {
                throw new Exception("Значение емкости стека должно быть в диапозоне от 1 до 500");
            }
        }
    }

    public event Action<T>? OnPush;

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
            // To do: Реализовать своё исключение.
            throw new Exception("Достигнута максимальная емкость стэка");
        }
    }

    // Данный метод удаляет элемент из стэка.
    public void Pop()
    {
        Count--;

        if (Count == 0 && OnEmpty is not null)
        {
            OnEmpty();
        }
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new Exception("Стек пуст");
        }

        return _elements[Count - 1];
    }
}