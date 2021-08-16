using System;
using System.Collections.Generic;
using Task1Lib;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleBinder = SimpleBinder.GetInstance();
            var values = new Dictionary<string, string>()
            {
                {"_Id", "5"},
                {"name", "Vasya"},
                {"id", "3"},
                {"_SecretName", "Agent007" },
                {"_justdouble", "20.5" }
            };

            var foo = simpleBinder.Bind<Foo>(values);
            var boo = simpleBinder.Bind<Boo>(values);
            Console.WriteLine(foo);
            Console.WriteLine(boo);

            var values2 = new Dictionary<string, string>()
            {
                {"Name", "Oleg"},
                {"_SecretName", "Bond" },
                {"_justdouble", "30.5" }
            };

            boo = simpleBinder.Bind<Boo>(values2);
            Console.WriteLine(boo);


        }
    }
}
