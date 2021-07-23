using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(default(string));
            Key c = new Key(Note.C, Accidental.Sharp, Octave.First);
            Console.WriteLine(c); // C# (1)
            Key d = new Key();
            Console.WriteLine(d);
            Console.WriteLine(c.Equals(d));
            Console.WriteLine(d.GetHashCode());
            Console.WriteLine(d.GetHashCode());
            Console.WriteLine(c.CompareTo(d));

        }
    }
}
