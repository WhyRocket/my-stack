using System.Collections;

namespace MyStack;

public sealed class MyLinkedList<T> : IEnumerable<T>
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
        Node<T> node = new(data);

        if (Count != 0)
        {
            _tail.Next = node;
            node.Previous = _tail;
        }
        else
        {
            _head = node;
        }

        _tail = node;

        Count++;
    }

    public void AddFirst(T data)
    {
        Node<T> node = new(data);

        if (Count != 0)
        {
            _head.Previous = node;
            node.Next = _head;
        }
        else
        {
            _tail = node;
        }

        _head = node;

        Count++;
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

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
