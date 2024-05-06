using MyStack.Exceptions;
using MyStack.Extensions;

namespace MyStack;

internal class Program
{
    static void Main(string[] args)
    {
        // Инициализация коллекции методов, которые выполняют задания.
        Action[] tasks =
        {
            MyLinkedListLinqTask1,
            MyLinkedListLinqTask2,
            MyLinkedListLinqTask3,
            MyLinkedListLinqTask4,
            MyLinkedListLinqTask5,
            MyLinkedListLinqTask6,
            MyLinkedListLinqTask7,
            MyLinkedListLinqTask8,
            MyLinkedListLinqTask9,
            MyLinkedListLinqTask10,
        };

        // Инициализация списка заданий.
        string[] taskConditions =
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

        // Отображение для пользователя полного списка заданий.
        Console.WriteLine($"Эта программа демонстрирует использование языка запросов LINQ на примере следующих заданий:\n");

        foreach (string task in taskConditions)
        {
            Console.WriteLine(task + "\n");
        }

        // Цикл, позволяющий последовательно посмотреть все задания.
        while (true)
        {
            Console.Write("\nВведите номер задания или любой другой символ для выхода для выхода: ");

            if (Int32.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= 10)
            {

                Console.WriteLine(taskConditions[taskNumber - 1] + "\nРешение:");
                tasks[taskNumber - 1]();
                Console.WriteLine();
            }
            else
            {
                return;
            }
        }
    }

    // Демонстрация работы стэка, созданного на основе односвязного списка.
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

    // Задание 1.
    public static void MyLinkedListLinqTask1()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();

        // Заполнение коллекции случайными целочисленными значениями.
        list.AddRange((random) => random.Next(30), 30);

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list
            .Where(item => item % 2 == 1)
            .Distinct()
            .ToConsole();
    }

    // Задание 2.
    public static void MyLinkedListLinqTask2()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();

        // Заполнение коллекции случайными целочисленными значениями.
        list.AddRange((random) => random.Next(-30, 30), 30);

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list
            .OrderBy(item => item)
            .Where(item => item >= 0 && item % 100 >= 10)
            .ToConsole();
    }

    // Задание 3.
    public static void MyLinkedListLinqTask3()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<string>();

        // Заполнение коллекции случайными строковыми значениями.
        list.AddRange((random) =>
        {
            var temp = "";
            var length = random.Next(2, 10);

            for (int i = 0; i < length; i++)
            {
                temp += (char)random.Next(65, 90);
            }

            return temp;
        }, 30);

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list
            .OrderBy(item => item.Length)
            .ThenByDescending(item => item[0])
            .ToConsole();
    }

    // Задание 4.
    public static void MyLinkedListLinqTask4()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<string>();

        // Заполнение коллекции случайными строковыми значениями.
        list.AddRange((random) =>
        {
            var temp = "";
            var length = random.Next(2, 10);

            for (int i = 0; i < length; i++)
            {
                temp += (char)random.Next(65, 90);
            }

            return temp;
        }, 10);

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list
            .Select(item => item[0])
            .Reverse()
            .ToConsole();
    }

    // Задание 5.
    public static void MyLinkedListLinqTask5()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();

        // Заполнение коллекции случайными целочисленными значениями.
        list.AddRange((random) => random.Next(-30, 30), 30);

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list
            .Where(item => item >= 0)
            .Select(item => item % 10)
            .Distinct()
            .ToConsole();
    }

    // Задание 6.
    public static void MyLinkedListLinqTask6()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<int>();

        // Заполнение коллекции случайными целочисленными значениями.
        list.AddRange((random) => random.Next(-30, 30), 10);

        var indexes = Enumerable.Range(1, list.Count());
        var indexedList = list
            .Zip(indexes, (Value, Index) => (Index, Value));

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        indexedList.ToConsole();

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        indexedList
            .Where(indexedItem => !(indexedItem.Index % 3 == 0))
            .Select(indexedItem =>
            {
                if (indexedItem.Index % 3 == 1)
                {
                    indexedItem.Value *= 2;
                }

                return indexedItem;
            })
            .ToConsole();
    }

    // Задание 7.
    public static void MyLinkedListLinqTask7()
    {
        // Инициализация коллекций и значений k1 и k2.
        var list1 = new MyLinkedList<int>();
        var list2 = new MyLinkedList<int>();

        var randomNumber = new Random();

        var k1 = randomNumber.Next(100);
        var k2 = randomNumber.Next(100);

        // Заполнение коллекций случайными целочисленными значениями.
        list1.AddRange((random) => random.Next(100), 5);
        list2.AddRange((random) => random.Next(100), 5);

        // Вывод на консоль коллекций.
        Console.WriteLine($"\nКоллекция элементов случайных значений:\n");

        Console.WriteLine($"Значение k1: {k1}");
        list1.ToConsole();

        Console.WriteLine($"\nЗначение k2: {k2}");
        list2.ToConsole();

        // Обработка коллекций и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list1
            .Where(item => item > k1);

        list2
            .Where(item => item < k2);

        list1
            .Union(list2)
            .OrderBy(item => item)
            .ToConsole();
    }

    // Задание 8.
    public static void MyLinkedListLinqTask8()
    {
        // Инициализация коллекций.
        var list1 = new MyLinkedList<int>();
        var list2 = new MyLinkedList<int>();

        // Заполнение коллекций случайными целочисленными значениями.
        list1.AddRange((random) => random.Next(100), 5);
        list2.AddRange((random) => random.Next(100), 5);

        // Вывод на консоль коллекций.
        Console.WriteLine($"\nКоллекция элементов случайных значений:\n");

        Console.WriteLine($"Первая коллекция:");
        list1.ToConsole();

        Console.WriteLine($"\nВторая коллекция");
        list2.ToConsole(); ;

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list1
            .Join(list2, Item1 => Item1 % 10, Item2 => Item2 % 10, (Item1, Item2) => (value1: Item1, value2: Item2))
            .Select(item => $"{item.value1}-{item.value2}")
            .ToConsole();
    }

    // Задание 9.
    public static void MyLinkedListLinqTask9()
    {
        // Инициализация коллекций.
        var list1 = new MyLinkedList<int>();
        var list2 = new MyLinkedList<int>();

        // Заполнение коллекций случайными целочисленными значениями.
        list1.AddRange((random) => random.Next(10), 5);
        list2.AddRange((random) => random.Next(10), 5);

        // Вывод на консоль коллекций.
        Console.WriteLine($"\nКоллекция элементов случайных значений:\n");

        Console.WriteLine($"Первая коллекция:");
        list1.ToConsole();

        Console.WriteLine($"\nВторая коллекция");
        list2.ToConsole();

        // Обработка коллекции и вывод на консоль.
        Console.WriteLine($"\nОбработанная коллекция:");

        list1
            .Zip(list2, (item1, item2) => item1 + item2)
            .Distinct()
            .OrderBy(item => item)
            .ToConsole();
    }

    // Задание 10.
    public static void MyLinkedListLinqTask10()
    {
        // Инициализация коллекции.
        var list = new MyLinkedList<ValueTuple<int, int, int, int>>();

        // Заполнение коллекции случайными целочисленными значениями.
        list.AddRange((random) => (list.Count + 1, random.Next(2020, 2023), random.Next(1, 12), random.Next(10, 24)), 10);

        // Вывод на консоль коллекции.
        Console.WriteLine($"\nКоллекция элементов случайных значений:");
        list.ToConsole();

        // Обработка коллекции и вывод на консоль.
        var minValue = list
            .Min(item => (item.Item4, item.Item2, item.Item3));

        Console.WriteLine($"\nОбработанная коллекция:\n{minValue}");
    }
}