namespace MyStack.Extensions;

public static class IEnumerableExtensions
{
    public static void ToConsole<T>(this IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine($"{item}");
        }
    }
}