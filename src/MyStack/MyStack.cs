namespace MyStack;

internal class MyStack<T>
{
    public event Action<string> OnCompleted;

    public T? Value
    {
        get
        {
            return Value;
        }
        set
        {
            if (value is null)
            {
                OnCompleted($"Стэк стал пустым");
            }
            else
            {
                OnCompleted($"Добавлен новый элемент: {Value}");
            }

            Value = value;
        }
    }
}