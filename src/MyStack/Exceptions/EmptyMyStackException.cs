namespace MyStack.Exceptions;

public class EmptyMyStackException : MyStackException
{
    public EmptyMyStackException()
        : base("Stack is empty") { }
}