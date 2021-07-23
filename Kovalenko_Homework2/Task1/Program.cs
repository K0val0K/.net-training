using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Test cases 1,2,3:");
        var arr = new int[5] { 1, 2, 3, 2, 1 };
        var test1 = new DiagonalMatrix(arr);
        var test2 = new DiagonalMatrix(5, 3, 2, 7, 7, 8);
        var test3 = new DiagonalMatrix(null);

        Console.WriteLine($"{test1.ToString()} size: {test1.Size}");
        Console.WriteLine($"{test2.ToString()} size: {test2.Size}");
        Console.WriteLine($"{test3.ToString()} size: {test3.Size}");


        Console.WriteLine("test case 4:");
        var testIndex = new DiagonalMatrix(1, 1, 1, 1);
        Console.WriteLine(testIndex[1, 1]);
        testIndex[1, 1] = 3;
        Console.WriteLine(testIndex[1, 1]);
        testIndex[1, 2] = 3;
        Console.WriteLine(testIndex[1, 2]);
        testIndex[4, 4] = 7;
        Console.WriteLine(testIndex[7, 7]);

        Console.WriteLine("test method Track():");
        Console.WriteLine(test1.Track());
        Console.WriteLine(test3.Track());
        Console.WriteLine(testIndex.Track()); // index[1,1] has changed

        Console.WriteLine("test Equals() and GetHashCode()");
        var x = new DiagonalMatrix(1, 1);
        var y = new DiagonalMatrix(1, 1);
        var z = new DiagonalMatrix(1, 1);
        Console.WriteLine(x.Equals(x));
        Console.WriteLine($"{x.Equals(y)} == {y.Equals(x)}");
        Console.WriteLine($"{x.Equals(y) && y.Equals(z) == true} -> {x.Equals(z) == true}");
        Console.WriteLine(x.Equals(null));
        var k = new DiagonalMatrix(1, 2);
        Console.WriteLine(x.Equals(k));

        Console.WriteLine($"Hash Codes: {x.GetHashCode()} == {y.GetHashCode()} == {z.GetHashCode()} != {k.GetHashCode()}");

        Console.WriteLine("test sum:");
        var sumMatrix = x.Sum(test2);
        Console.WriteLine(sumMatrix.ToString());
        sumMatrix = test2.Sum(test1);
        Console.WriteLine(sumMatrix.ToString());
        Console.WriteLine(x.Sum(z).ToString());
    }
}

