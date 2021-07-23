public class Stack<T> : IStack<T>
{
    private int index;
    private readonly T[] data = new T[stackLength];
    private static int stackLength = 100;

    public bool IsEmpty()
    {
        return index < 1;
    }

    public T Pop()
    {
        return IsEmpty() ? default(T) : data[--index];
    }

    public void Push(T element)
    {
        if(index + 1 != stackLength)
        {
            data[index++] = element;
        } 
    }
}

