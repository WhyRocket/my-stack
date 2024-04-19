using MyStack.Exceptions;

namespace MyStack;

internal class Program
{
    static void Main(string[] args)
    {
        MyLinkedListDemo();
    }
    public static void MyStackDemo()
    {
        MyStack<int> stack = new(10);

        // Событие добавления элемента в стек.
        stack.OnPush += (value) => Console.WriteLine($"Добавлен элемент: {value}");

        // Событие удаление элемента из стека.
        stack.OnPop += (value) => Console.WriteLine($"Удален элемент: {value}");

        // Событие опустошения стека.
        stack.OnEmpty += () => Console.WriteLine("СТЭК ПУСТ !!!");


        // Демонстрация работы методов
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
        catch (CapacityExceededMyStackException ex)
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
        catch (EmptyMyStackException ex)
        {
            Console.WriteLine($"Ошибка!\nТекст ошибки: {ex.Message}");
        }

        // Демонстрация работы исключения объявления стека больше допустимого максимума.
        Console.WriteLine();

        try
        {
            MyStack<int> stack3 = new(1000);
        }
        catch (CapacityExceededMyStackException ex)
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
        catch (EmptyMyStackException ex)
        {
            Console.WriteLine($"Ошибка!\nТекст ошибки: {ex.Message}");
        }
    }

    public static void MyLinkedListDemo()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int?>();

        // Демонстрация добавления элементов.
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);

        list.AddLast(4);
        list.AddLast(5);
        list.AddLast(6);

        Console.WriteLine("В коллекцию добавлено 6 элементов:");

        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }

        // Демонстрация удаления элементов из коллекции.
        list.Remove(3);
        list.Remove(4);

        Console.WriteLine("\nИз коллекции удалены элементы \"3\" и \"4\":");

        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }

        // Демонстрация работы исключения.
        Console.WriteLine("\nПопытка добавить null элемент:");

        try
        {
            list.AddFirst(null);
        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка! {ex.Message}");
        }

        // Демонстрация очистки коллекции.
        list.Clear();

        Console.WriteLine("\nКоллекция отчищена:");

        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }
    }
}

