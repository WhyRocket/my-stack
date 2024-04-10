namespace MyStack.Exceptions;

public class EmptyStackException : Exception
{
    public EmptyStackException()
        : base("Стек пуст") { }
}