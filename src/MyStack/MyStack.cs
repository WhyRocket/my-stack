namespace MyStack;

public class MyStack<T>
{
    private readonly T[] _elements;

    public int Count { get; private set; }

    public int Capacity { get; init; }

    public event Action<T>? OnPush;

    public event Action? OnEmpty;

    public MyStack(int capacity)
    {
        Capacity = capacity;
        _elements = new T[capacity];
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
        if (Count > 0)
        {
            Count--;

            if (Count == 0 && OnEmpty is not null)
            {
                OnEmpty();
            }
        }
        else
        {
            throw new Exception("Стек пуст");
        }
    }
}