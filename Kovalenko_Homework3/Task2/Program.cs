using System;

class Program
{
    static void Main(string[] args)
    {
        var a = new Stack<int>();
        a.Push(5);
        a.Push(3);
        Console.WriteLine(a.IsEmpty());
        Console.WriteLine(a.Pop());
        Console.WriteLine(a.Pop());
        Console.WriteLine(a.Pop());
        for(int i = 0; i < 102; i++)
        {
            a.Push(7);
        }
        a.Push(3);
        Console.WriteLine(a.Pop());
        Console.WriteLine("...................................");
        var b = new Stack<int>();
        b.Push(1);
        b.Push(2);
        b.Push(3);
        var c = b.Reverse();
        while(!c.IsEmpty())
        {
            Console.WriteLine(c.Pop());
        }
        var d = new Stack<string>();
        d.Push("st");
        Console.WriteLine(d.Pop());
    }
}

