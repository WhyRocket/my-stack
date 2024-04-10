namespace MyStack.Exceptions;

public class MaxCapacityExceededException : Exception
{
    public MaxCapacityExceededException() 
        : base("Достигнута максимальая емкость стека") { }

    public MaxCapacityExceededException(int maxCapacity)
        : base($"Значение емкости стека должно быть в диапозоне от 1 до {maxCapacity}") { }
}