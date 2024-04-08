namespace MyStack;

public class MyStack<T>(int capacity)
{
    private readonly T[] _elements = new T[capacity];

    public int Count { get; private set; }

    public int Capacity { get; init; } = capacity;

    public event Action<T>? OnPush;

    public event Action? OnEmpty;


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
}