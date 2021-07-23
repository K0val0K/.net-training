using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 
            var x = new Rational(2, 6);
            var y = new Rational(-6, 3);
            var z = new Rational(0, 5);
            Console.WriteLine($"x = {x} y = {y} z = {z}");
            //2
            try
            {
                var wrong = new Rational(1, 0);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // 3
            var x1 = new Rational(1, 1);
            var x2 = new Rational(1, 1);
            var x3 = new Rational(1, 1);
            var x4 = new Rational(2, 1);
            Console.WriteLine(x1.Equals(x1));
            Console.WriteLine(x1.Equals(x2) + " " + x2.Equals(x1));
            Console.WriteLine(x1.Equals(x2) + " " + x2.Equals(x3) + " " + x1.Equals(x3));
            Console.WriteLine(x1.Equals(null) + " " + x2.Equals(null));
            Console.WriteLine(x1.GetHashCode() + " " + x2.GetHashCode() + " " + x4.GetHashCode());

            // 4
            var y1 = new Rational(1, 1);
            var y2 = new Rational(2, 2);
            var y3 = new Rational(-1, 3);
            Console.WriteLine(y1.CompareTo(y2));
            Console.WriteLine(y1.CompareTo(y3));
            Console.WriteLine(y3.CompareTo(y1));

            //5
            x = new Rational(1, 2);
            y = new Rational(-1, 2);
            Console.WriteLine(x + y); // 0
            Console.WriteLine(x - y); // 1/1
            Console.WriteLine(y - y); // -1/1
            Console.WriteLine(x * y); // -1/4
            Console.WriteLine(x / y); //-1/1
            try
            {
                var c = x / 0 ; //int convertion 6
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine((x - y) * 2 / x); // -1/2 - (-1/2) * 2 / 1/2 = 4/1
            Console.WriteLine((double)y); // -0.5
        }
    }
}
