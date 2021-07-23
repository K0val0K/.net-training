using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var m = new DiagonalMatrix<int>(4);
            //var c = new DiagonalMatrix<string>(3);
            //m[0, 0] = 1;
            //m[1, 1] = 2;
            //m[2, 2] = 3;
            //m[3, 3] = 4;
            //c[0, 0] = "a";
            //c[1 ,1] = "b";
            //c[2, 2] = "c";
            //var n = m.Add(c, (left, right) =>
            //{
            //    return left.ToString() + right;
            //});
            ////m.ElementChanged += (_, e) => Console.WriteLine($"Old = {e.Old}, New = {e.New}, Index = {e.Index}");
            //m[0, 0] = 1;
            //m[1, 1] = 1;
            //var d = new MatrixTracker<int>(m);
            //m[0, 0] = 5;
            //m[1, 1] = 3;
            //Console.WriteLine(m[0, 0]);
            //Console.WriteLine(m[1, 1]);
            //d.Undo();
            //Console.WriteLine(m[0, 0]);
            //d.Undo();
            //Console.WriteLine(m[1, 1]);

            //1,2,3 test
            var testInt = new DiagonalMatrix<int>();
            Console.WriteLine(testInt.Size); // 0
            try
            {
                testInt = new DiagonalMatrix<int>(-1);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message); // index must be positive
            }
            testInt = new DiagonalMatrix<int>(5);
            Console.WriteLine($"test1_2 size: {testInt.Size}"); // 3
            for (var i = 0; i < testInt.Size; i++)
            {
                testInt[i, i] = i;
            }
            testInt[0, 1] = 10;
            Console.WriteLine($"default int value: {testInt[0, 1]}"); // 0

            try
            {
                testInt[6, 6] = 10;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message); // out of range
            }
            try
            {
                var c = testInt[7, 7];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message); // out of range
            }
            //test 5,6
            var testString = new DiagonalMatrix<string>(3);
            testString.ElementChanged += (_, e) => Console.WriteLine($"Old = {e.Old}, New = {e.New}, Index = {e.Index}");
            testString[0, 0] = "one";
            testString[1, 1] = "two";
            testString[2, 2] = "three";
            testString[2, 2] = "threeNew";

            testString[0, 0] = "one";

            var testDouble = new DiagonalMatrix<double>(4);
            for (var i = 0; i < testDouble.Size; i++)
            {
                testDouble[i, i] = 0.5 + i;
            }

            var outTest = testString.Add(testDouble, (val1, val2) => val1 + "Test" + val2.ToString());
            Console.WriteLine(outTest.Size); // 4;
            for (var i = 0; i < outTest.Size; i++)
            {
                Console.Write(outTest[i, i] + " "); // oneTest0,5 twoTest1,5 threeNewTest2,5 Test3,5
            }
            Console.WriteLine();
            var outTest2 = testInt.Add(testDouble,(val1, val2) => (double)val1 + val2 + 10);
            for (var i = 0; i < outTest2.Size; i++)
            {
                Console.Write(outTest2[i, i] + " "); // 10,5 12,5 14,5 16,5 14
            }
            Console.WriteLine();

            //test 7
            var testBackup = new DiagonalMatrix<string>(2);
            testBackup[0, 0] = "init1";
            testBackup[1, 1] = "init2";
            var tracker = new MatrixTracker<string>(testBackup);
            Console.WriteLine($"initial values: {testBackup[0, 0]} {testBackup[1, 1]}");
            testBackup[0, 0] = "changed1";
            Console.WriteLine($"current values0: {testBackup[0, 0]} {testBackup[1, 1]}");
            tracker.Undo();
            Console.WriteLine($"current values1: {testBackup[0, 0]} {testBackup[1, 1]}");
            testBackup[0, 0] = "changed1";
            testBackup[1, 1] = "changed2";
            Console.WriteLine($"current values2: {testBackup[0, 0]} {testBackup[1, 1]}");
            tracker.Undo();
            Console.WriteLine($"current values3: {testBackup[0, 0]} {testBackup[1, 1]}");
            tracker.Undo();
            Console.WriteLine($"current values4: {testBackup[0, 0]} {testBackup[1, 1]}");
            testBackup[0, 0] = "changed1";
            testBackup[0, 0] = "changed1_1";
            Console.WriteLine($"current values5: {testBackup[0, 0]} {testBackup[1, 1]}");
            tracker.Undo();
            Console.WriteLine($"current values6: {testBackup[0, 0]} {testBackup[1, 1]}");




        }
    }

    
}
