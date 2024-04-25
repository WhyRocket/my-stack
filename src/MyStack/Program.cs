using MyStack.Exceptions;
using MyStack.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStack;

internal class Program
{
    static void Main(string[] args)
    {
        string[] tasks = 
            { "1. Дана целочисленная последовательность. Извлечь из нее все нечетные числа, сохранив их исходный порядок следования и удалив все вхождения повторяющихся элементов, кроме первых.",
              "2. Дана целочисленная последовательность. Извлечь из нее все положительные двузначные числа, отсортировав их по возрастанию.",
              "3. Дана строковая последовательность. Строки последовательности содержат только заглавные буквы латинского алфавита. Отсортировать последовательность по возрастанию длин строк, а строки одинаковой длины – по убыванию.",
              "4. Дана последовательность непустых строк A. Получить последовательность символов, каждый элемент которой является начальным символом соответствующей строки из A. Порядок символов должен быть обратным по отношению к порядку элементов исходной последовательности.",
              "5. Дана целочисленная последовательность. Обрабатывая только положительные числа, получить последовательность их последних цифр и удалить в полученной последовательности все вхождения одинаковых цифр, кроме первого. Порядок полученных цифр должен соответствовать порядку исходных чисел.",
              "6. Дана целочисленная последовательность A. Получить новую последовательность чисел, элементы которой определяются по соответствующим элементам последовательности A следующим образом: если порядковый номер элемента A делится на 3 (3, 6, …), то этот элемент в новую последовательность не включается; если остаток от деления порядкового номера на 3 равен 1 (1, 4, …), то в новую последовательность добавляется удвоенное значение этого элемента; в противном случае (для элементов A с номерами 2, 5, …) элемент добавляется в новую последовательность без изменений. В полученной последовательности сохранить исходный порядок следования элементов.",
              "7. Даны целые числа K1 и K2 и целочисленные последовательности A и B. Получить последовательность, содержащую все числа из A, большие K1, и все числа из B, меньшие K2. Отсортировать полученную последовательность по возрастанию.",
              "8. Даны последовательности положительных целых чисел A и B; все числа в каждой последовательности различны. Найти последовательность всех пар чисел, удовлетворяющих следующим условиям: первый элемент пары принадлежит последовательности A, второй принадлежит B, и оба элемента оканчиваются одной и той же цифрой. Результирующая последовательностьназывается внутренним объединением последовательностей A и B по ключу, определяемому последними цифрами исходных чисел. Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, разделенные дефисом, например, «49-129». Порядок следования пар должен определяться исходным порядком элементов последовательности A, а для равных первых элементов – порядком элементов последовательности B.",
              "9. Даны целочисленные последовательности A и B. Получить последовательность всех различных сумм, в которых первое слагаемое берется из A, а второе из B. Упорядочить полученную последовательность по возрастанию",
              "10. Исходная последовательность содержит сведения о клиентах фитнес-центра. Каждый элемент последовательности включает следующие целочисленные поля: <Код клиента>; <Год>; <Номер месяца>; <Продолжительность занятий (в часах)>; Найти элемент последовательности с минимальной продолжительностью занятий. Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке). Если имеется несколько элементов с минимальной продолжительностью, то вывести данные того из них, который является последним в исходной последовательности." };


        Console.WriteLine($"Эта программа демонстрирует использование языка запросов LINQ на примере следующих заданий:\n");

        foreach (string task in tasks)
        {
            Console.WriteLine(task + "\n");
        }

        while (true)
        {

            Console.Write("\nВведите номер задания или \"0\" для выхода: ");

            var ans = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (ans)
            {
                case 1:
                    Console.WriteLine(tasks[0] + "\nРешение:");
                    MyLinkedListLinqTask1();
                    break;

                case 2:
                    Console.WriteLine(tasks[1] + "\nРешение:");
                    MyLinkedListLinqTask2();
                    break;

                case 3:
                    Console.WriteLine(tasks[2] + "\nРешение:");
                    MyLinkedListLinqTask3();
                    break;

                case 4:
                    Console.WriteLine(tasks[3] + "\nРешение:");
                    MyLinkedListLinqTask4();
                    break;

                case 5:
                    Console.WriteLine(tasks[4] + "\nРешение:");
                    MyLinkedListLinqTask5();
                    break;

                case 6:
                    Console.WriteLine(tasks[5] + "\nРешение:");
                    MyLinkedListLinqTask6();
                    break;

                case 7:
                    Console.WriteLine(tasks[6] + "\nРешение:");
                    MyLinkedListLinqTask7();
                    break;

                case 8:
                    Console.WriteLine(tasks[7] + "\nРешение:");
                    MyLinkedListLinqTask8();
                    break;

                case 9:
                    Console.WriteLine(tasks[8] + "\nРешение:");
                    MyLinkedListLinqTask9();
                    break;

                case 10:
                    Console.WriteLine(tasks[9] + "\nРешение:");
                    MyLinkedListLinqTask10();
                    break;

                default:
                    Console.WriteLine();
                    return;
            }
        }
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
        catch (ArgumentNullException ex)
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

    public static void MyLinkedListLinqDemo()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int?>();
        var rnd = new Random();

        // Демонстрация добавления элементов.
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);

        list.AddLast(4);
        list.AddLast(5);
        list.AddLast(6);

        Console.WriteLine("Стартовая коллекция:");

        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }

        Console.WriteLine("\nОставляем только четные элементы:");

        var list2 = list.Where(x => x % 2 == 0);

        foreach (var item in list2)
        {
            Console.WriteLine($"{item}");
        }

        Console.WriteLine("\nСортировка по возрастанию:");

        var list3 = list.OrderBy(item => item.Value);

        foreach (var item in list3)
        {
            Console.WriteLine($"{item}");
        }

        Console.WriteLine($"\nМинимальное значение: {list.Min(p => p.Value)}");

        Console.WriteLine($"\nМаксимальное значение: {list.Max(p => p.Value)}");

        Console.WriteLine($"\nСреднее значение: {list.Average(p => p.Value)}");

        Console.WriteLine($"\nСумма: {list.Sum(p => p.Value)}");

        list.Clear();

        for (int i = 0; i < 20; i++)
        {
            list.AddFirst(rnd.Next(1000));
        }

        Console.WriteLine($"\nКоллекция элементов случайных значений:");

        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }

        var list4 = list
            .Where(item => item % 2 == 0)
            .OrderBy(item => item)
            .Reverse();

        Console.WriteLine($"\nКоллекция элементов после сортировки:");

        foreach (var item in list4)
        {
            Console.WriteLine($"{item}");
        }
    }

    public static void MyLinkedListLinqTask1()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();
        var rnd = new Random();

        // Заполнение коллекции случайными целочисленными значениями.
        for (int i = 0; i < 20; i++)
        {
            list.AddLast(rnd.Next(10));
        }

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции.
        var listNew = list
            .Where(item => item % 2 == 1)
            .Distinct();

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }

    public static void MyLinkedListLinqTask2()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();
        var rnd = new Random();

        // Заполнение коллекции случайными целочисленными значениями.
        for (int i = 0; i < 30; i++)
        {
            list.AddLast(rnd.Next(-30, 30));
        }

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции.
        var listNew = list
            .OrderBy(item => item)
            .Where(item => item >= 0 && item % 100 >= 10);

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }

    public static void MyLinkedListLinqTask3()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<string>();
        var rnd = new Random();

        // Заполнение коллекции случайными строковыми значениями.
        for (int i = 0; i < 30; i++)
        {
            var temp = "";
            var length = rnd.Next(2, 10);

            for (int j = 0; j < length; j++)
            {
                temp += (char)rnd.Next(65, 90);
            }

            list.AddLast(temp);
        }

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции.
        var listNew = list
            .OrderBy(item => item.Length)
            .ThenByDescending(item => item[0]);

        // Вывод на консоль обработанной коллеции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }

    public static void MyLinkedListLinqTask4()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<string>();
        var rnd = new Random();

        // Заполнение коллекции случайными строковыми значениями.
        for (int i = 0; i < 10; i++)
        {
            var temp = "";
            var length = rnd.Next(2, 10);

            for (int j = 0; j < length; j++)
            {
                temp += (char)rnd.Next(65, 90);
            }

            list.AddLast(temp);
        }

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        var listNew = list
            .Select(item => item[0])
            .Reverse();

        // Вывод на консоль обработанной коллеции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }

    public static void MyLinkedListLinqTask5()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();
        var rnd = new Random();

        // Заполнение коллекции случайными целочисленными значениями.
        for (int i = 0; i < 30; i++)
        {
            list.AddLast(rnd.Next(-30, 30));
        }

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции.
        var listNew = list
            .Where(item => item >= 0)
            .Select(item => item % 10)
            .Distinct();

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }

    public static void MyLinkedListLinqTask6()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();
        var rnd = new Random();

        // Заполнение коллекции случайными целочисленными значениями.
        for (int i = 0; i < 10; i++)
        {
            list.AddLast(rnd.Next(-30, 30));
        }
        var listIndex = Enumerable.Range(0, list.Count());
        var indexedList = list
            .Zip(listIndex, (val, ind) => (index: ind, value: val));

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        indexedList.ToConsole();

        // Обработка коллекции.
        var listNew = indexedList
            .Where(item => !(item.index % 3 == 0))
            .Select(item =>
            {
                if (item.index % 3 == 1)
                {
                    item.value *= 2;
                }

                return item;
            });

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }
    
    public static void MyLinkedListLinqTask7()
    {
        // Инициализация коллекций и значений k1 и k2.
        var list1 = new MyLinkedList<int>();
        var list2 = new MyLinkedList<int>();

        var rnd = new Random();

        var k1 = rnd.Next(100);
        var k2 = rnd.Next(100);

        // Заполнение коллекций случайными целочисленными значениями.
        for (int i = 0; i < 5; i++)
        {
            list1.AddLast(rnd.Next(100));
            list2.AddLast(rnd.Next(100));
        }

        // Вывод на консоль коллекций.
        Console.WriteLine($"\nКоллекция элементов случайных значений:\n");

        Console.WriteLine($"Значение k1: {k1}");
        list1.ToConsole();

        Console.WriteLine($"\nЗначение k2: {k2}");
        list2.ToConsole();

        // Обработка коллекций.
        var list1New = list1
            .Where(item => item > k1);

        var list2New = list2
            .Where(item => item < k2);

        var listNew = list1New
            .Union(list2New)
            .OrderBy(item => item);

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }

    public static void MyLinkedListLinqTask8()
    {
        // Инициализация коллекций.
        var list1 = new MyLinkedList<int>();
        var list2 = new MyLinkedList<int>();
        var rnd = new Random();

        // Заполнение коллекций случайными целочисленными значениями.
        for (int i = 0; i < 5; i++)
        {
            list1.AddLast(rnd.Next(100));
            list2.AddLast(rnd.Next(100));
        }

        // Вывод на консоль коллекций.
        Console.WriteLine($"\nКоллекция элементов случайных значений:\n");

        Console.WriteLine($"Первая коллекция:");
        list1.ToConsole();

        Console.WriteLine($"\nВторая коллекция");
        list2.ToConsole();;

        // Обработка коллекций.
        var listMerged = list1
            .Join(list2, item1 => item1 % 10, item2 => item2 % 10, (item1, item2) => (val1: item1, val2: item2))
            .Select(item => $"{item.val1}-{item.val2}");

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listMerged.ToConsole();
    }

    public static void MyLinkedListLinqTask9()
    {
        // Инициализация коллекций.
        var list1 = new MyLinkedList<int>();
        var list2 = new MyLinkedList<int>();
        var rnd = new Random();

        // Заполнение коллекций случайными целочисленными значениями.
        for (int i = 0; i < 5; i++)
        {
            list1.AddLast(rnd.Next(10));
            list2.AddLast(rnd.Next(10));
        }

        // Вывод на консоль коллекций.
        Console.WriteLine($"\nКоллекция элементов случайных значений:\n");

        Console.WriteLine($"Первая коллекция:");
        list1.ToConsole();

        Console.WriteLine($"\nВторая коллекция");
        list2.ToConsole();

        // Обработка коллекций.

        var listNew = list1
            .Zip(list2, (item1, item2) => item1 + item2)
            .Distinct()
            .OrderBy(item => item);

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:");
        listNew.ToConsole();
    }

    public static void MyLinkedListLinqTask10()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<ValueTuple<int, int, int, int>>();
        var rnd = new Random();

        // Заполнение коллекции случайными целочисленными значениями.
        for (int i = 1; i <= 10; i++)
        {
            list.AddLast((i, rnd.Next(2020, 2023), rnd.Next(1, 12), rnd.Next(10, 24)));
        }

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции.
        var newList = list
            .Min(item => (item.Item4, item.Item2, item.Item3));

        // Вывод на консоль обработанной коллекции.
        Console.WriteLine($"\nОбработанная коллекция:\n{newList}");
    }
}