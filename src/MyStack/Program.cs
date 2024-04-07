namespace MyStack;

internal class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new (10);

        stack.OnPush += (value) => Console.WriteLine(value);

        stack.OnEmpty += () =>
        {
            Console.WriteLine("СТЭК ПУСТ !!!");
        };
        
        stack.Push(1);
        stack.Pop();
    }
}

