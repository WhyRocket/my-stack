namespace MyStack;

internal class MyLinkedList<T>
{
    private sealed class Node<T>(T value)
    {
        public T Value { get; set; } = value;
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }
    }

    private Node<T>? head;
    private Node<T>? tail;
}
