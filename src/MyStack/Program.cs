namespace MyStack;

internal class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new(10);

        // Событие добавления элемента в стек.
        stack.OnPush += (value) => Console.WriteLine($"Добавлен элемент: {value}");

        // Событие удаление элемента из стека.
        stack.OnPop += (value) => Console.WriteLine($"Удален элемент: {value}");

        // Событие опустошения стека.
        stack.OnEmpty += () => Console.WriteLine("СТЭК ПУСТ !!!");


        // Демонстрация рабоыт методов
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine();

        Console.WriteLine($"Верхний элемент в стеке: {stack.Peek()}");

        Console.WriteLine();

        stack.Pop();
        stack.Pop();
        stack.Pop();

        // Демонстрация работы исключения переполнения стека.
        Console.WriteLine();
        MyStack<int> stack1 = new(2);

        try
        {
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);
        }
        catch (InvalidOperationException ex) 
        {
            Console.WriteLine($"Ошибка!\nТекст ошибки: {ex.Message}");
        }

        // Демонстрация работы исключения удаления элемента из пустого стека.
        Console.WriteLine();
        MyStack<int> stack2 = new(3);

        try
        {
            stack2.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка!\nТекст ошибки: {ex.Message}");
        }

        // Демонстрация работы исключения объявления стека больше допустимого максимума.
        Console.WriteLine();

        try
        {
            MyStack<int> stack3 = new(1000);
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка!\nТекст ошибки: {ex.Message}");
        }

        // Демонстрация работы исключения взятия элемента из пустого стека.
        Console.WriteLine();

        MyStack<int> stack4 = new(3);

        try
        {
            stack4.Peek();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка!\nТекст ошибки: {ex.Message}");
        }
    }
}

