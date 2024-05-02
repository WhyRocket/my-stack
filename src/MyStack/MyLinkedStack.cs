using MyStack.Exceptions;

namespace MyStack;

public class MyLinkedStack<T>
{
    private class Node(T value)
    {
        public T Value { get; init; } = value;
        public Node? Previous { get; set; }
    }

    // Верхний элемент стека.
    private Node? _top;

    // Свойство, которое возвращает количесвто элементов в стеке.
    public int Count { get; private set; }

    // Метод для добавления элемента.
    public void Push (T data)
    {
        Node node = new(data);

        if (_top is not null)
        {
            node.Previous = _top;
            _top = node;
        }
        else
        {
            _top = node;
        }

        Count++;
    }

    // Метод для удаления элемента.
    public T Pop()
    {
        Node node;

        if (_top is not null)
        {
            node = _top;
            _top = _top.Previous;
            Count--;
        }
        else
        {
            throw new EmptyMyStackException();
        }

        return node.Value;
    }

    // Метод для считывания верхнего элемента.
    public T Peek ()
    {
        if (_top is null)
        {
            throw new EmptyMyStackException();
        }

        return _top.Value;
    }
}