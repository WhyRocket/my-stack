namespace MyStack.Extensions;

public static class MyLinkedListExtensions
{
    public static void AddRange<T>(this MyLinkedList<T> list, Func<Random, T> function, int size)
    {
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            list.AddLast(function(random));
        }
    }
}
