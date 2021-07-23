public interface IStack<T>
{
    public void Push(T e);
    public T Pop();
    public bool IsEmpty();
}

