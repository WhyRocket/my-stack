namespace MyStack.Exceptions;

public class CapacityExceededMyStackException : MyStackException
{
    public int MaxCapacity {  get; init; }

    public CapacityExceededMyStackException(int maxCapacity)
        : base($"The stack capacity value must be in the range from 1 to {maxCapacity}")
    {
        MaxCapacity = maxCapacity;
    }
}