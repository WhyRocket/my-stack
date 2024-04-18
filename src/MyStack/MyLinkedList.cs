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
}
