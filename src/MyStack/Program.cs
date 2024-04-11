namespace MyStack;

internal class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new(10);

        stack.OnPush += (value) => Console.WriteLine($"Добавлен элемент: {value}");

        stack.OnPop += (value) => Console.WriteLine($"Удален элемент: {value}");

        stack.OnEmpty += () => Console.WriteLine("СТЭК ПУСТ !!!");

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine($"Верхний элемент в стеке: {stack.Peek()}");

        stack.Pop();
        stack.Pop();
        stack.Pop();

        //// Исключение переполнения стека.
        //MyStack<int> stack1 = new(2);

        //stack1.Push(3);
        //stack1.Push(4);
        //stack1.Push(5);

        //// Исключение удаления элемента из пустого стека.
        //MyStack<int> stack2 = new(3);

        //stack2.Pop();

        //// Исключения объявления стека больше допустимого максимума.

        //MyStack<int> stack3 = new(1000);

        //// Исключения взятия элемента из пустого стека.

        //MyStack<int> stack4 = new(3);

        //stack4.Peek();
    }
}

