using System.Collections;
using System.Xml.Linq;

namespace MyStack;

public sealed class MyLinkedList<T> : IEnumerable<T>
{
    private sealed class Node(T value)
    {
        public T Value { get; init; } = value;

        public Node? Next { get; set; }

        public Node? Previous { get; set; }
    }

    private Node? _head;
    private Node? _tail;

    public int Count { get; private set; }

    public void AddLast(T data)
    {
        Node node = new(data);

        if (Count != 0)
        {
            _tail!.Next = node;
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
        Node node = new(data);

        if (Count != 0)
        {
            _head!.Previous = node;
            node.Next = _head;
        }
        else
        {
            _tail = node;
        }

        _head = node;

        Count++;
    }

    public void Remove(T value)
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        Node node = _head!;

        while (node is not null)
        {
            if (node.Value!.Equals(value))
            {
                if (node.Next is not null && node.Previous is not null)
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    Count--;
                } 
                else if (node.Previous is not null)
                { 
                    node.Previous.Next = null;
                }
                else
                {
                    Clear();
                }
            }
        }
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

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<T> GetEnumerator()
    {
        var node = _head;

        while (node is not null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }
}
