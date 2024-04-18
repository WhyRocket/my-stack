namespace MyStack;

public sealed class MyLinkedList<T>
{
    private sealed class Node<T>(T value)
    {
        public T Value { get; init; } = value;
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }
    }

    private Node<T>? _head;
    private Node<T>? _tail;

    public int Count { get; private set; }

    public void AddLast(T data)
    {

    }

    public void AddFirst(T data)
    {

    }

    public void Remove()
    {

    }

    public void Clear()
    {
        Count = 0;
        _head = null;
        _tail = null;

    }

    public bool Contains(T data)
    {
        return true;
    }
}
