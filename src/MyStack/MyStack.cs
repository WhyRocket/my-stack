namespace MyStack;

public class MyStack<T>
{
    private int count = 0;
    public event Action<string> EventChangeValue;
    public event Action<string> EventStackVoid;

    private T[] Elements { get; set; } = new T[10];

    // Данный метод добавляет элемент в стэк.
    public void AddElement(T element)
    {
        if ((count - 1) == Elements.Length)
        {
            Elements[count++] = element;
            EventChangeValue($"Добавленн элемент: {element}");
        }
    }

    // Данный метод удаляет элемент из стэка.
    public void DeleteElement()
    {
        if (count == 0)
        {
            EventStackVoid($"Стэк пуст");
        }
        Elements[count--] = default(T);
    }
}