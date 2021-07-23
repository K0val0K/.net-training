using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new SparseMatrix(3, 5);
            Console.WriteLine(x);
            x[0, 0] = 1;
            x[0, 2] = 3;
            x[1, 1] = 2;
            x[1, 2] = 3;
            x[1, 4] = 5;
            x[2, 0] = 1;
            x[2, 1] = 2;
            x[2, 2] = 3;
            x[2, 3] = 4;
            Console.WriteLine(x);
            //x[0, 0] = 1;
            //x[2, 0] = 1;
            //x[1, 1] = 2;
            //x[2, 2] = 2;
            //Console.WriteLine(x);
            ////Console.WriteLine(x.GetCount(1));
            ////Console.WriteLine(x.GetCount(2));
            ////Console.WriteLine(x.GetCount(0));
            var enumerator = x.GetNonzeroElements();
            foreach (var coordinate in enumerator)
            {
                Console.WriteLine(coordinate);
            }


            foreach (var item in x)
            {
                Console.Write(item);
            }

        }
    }
}
