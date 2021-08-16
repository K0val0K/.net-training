using System;
using Task1Lib;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var f1 = new Person1(1) {Name = "Vayne", Age = 1 };
            var f2 = new Person2(2) {Name = "Andrew", Age = 2 };
            var f3 = new Person3(3) {Name = "Vasya", Age = 3 };
            var na = new NoAttributes(4) {Name = "John", Age = 4 };

            var logger = new Logger("log.json");

            logger.Track(f1);
            logger.Track(f2);
            logger.Track(f3);
            logger.Track(na);

            Console.WriteLine("Log data was saved on log.json file");
        }
    }
}
