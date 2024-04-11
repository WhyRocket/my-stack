namespace MyStack.Exceptions;

public class MyStackException : InvalidOperationException
{
    public MyStackException(string message)
        : base(message) { }
}
