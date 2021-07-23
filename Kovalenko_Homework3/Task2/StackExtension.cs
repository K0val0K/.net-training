public static class StackExtension
{
    public static Stack<T> Reverse<T>(this IStack<T> oldStack) 
    {
        var newStack = new Stack<T>();
        while (!oldStack.IsEmpty())
        {
            newStack.Push(oldStack.Pop());
        }
        return newStack; 
    }
}

