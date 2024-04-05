namespace MyStack;

public class MyStack<T>
{
    public int Count { get; private set; } = 0;
    public int Capacity { get; private set; }

    public event Action<string> onPush;
    public event Action<string> onEmpty;
    private T[] Elements { get; set; }

    public MyStack(int count, int capacity)
    {
        this.Count = count;
        Capacity = capacity;
        Elements = new T[capacity];
    }


    // Данный метод добавляет элемент в стэк.
    public void Push(T element)
    {
        if (Count < Capacity)
        {
            Elements[Count] = element;
            Count++;
            onPush($"Добавленн элемент: {element}");
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
        if (Count == 0)
        {
            onEmpty($"Стэк пуст");
            return;
        }
        Elements[Count] = default(T);
        Count--;
    }
}