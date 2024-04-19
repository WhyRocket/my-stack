namespace MyStack;

public class MyLinkedStack<T>
{
    private class Node(T value)
    {
        public T Value { get; set; } = value;
        public Node? Previous { get; set; }
    }

    // Верхний элемент стека.
    private Node? _head;

    // Свойство, которое возварщает количесвто элементов в стеке.
    public int Size { get; private set; }

    // Метод для добавления элемента.
    public void Push (T data)
    {

    }

    // Метод для удаления элемента.
    public void Pop()
    {

    }

    // Метод для считывания верхнего элемента.
    public T Peek ()
    {
        return default(T);
    }
}