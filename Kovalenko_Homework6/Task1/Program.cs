using System;
using System.Numerics;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var longNum = "61846837467813246312422"; // slow above 1min 
            //var x = BigInteger.Parse(longNum); // похоже что не судьба мне уронить курс биткоина с этим алгоритмом :(
            //var y = BigInteger.Parse(longNum);

            //var x = new BigInteger(200); // one thread faster
            //var y = new BigInteger(525);

            var x = new BigInteger(3454652434524628728);
            var y = new BigInteger(13142349898212789898);

            Console.WriteLine("Waiting for sync factorization");

            var benchmark = Stopwatch.StartNew();
            var res1 = CryptoMiner.Factorization(x);
            benchmark.Stop();

            Console.WriteLine($"First number calcualtion time = {benchmark.ElapsedMilliseconds} ms");
            benchmark.Restart();
            var res2 = CryptoMiner.Factorization(y);
            benchmark.Stop();

            Console.WriteLine($"Second number calculation time = {benchmark.ElapsedMilliseconds} ms");

            Console.Write("First number: ");
            foreach (var num in res1)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.Write("Second number: ");
            foreach (var num in res2)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\nWaiting for async factorization");

            benchmark.Restart();
            var ares1 = CryptoMiner.FactorizationAsync(x);
            var ares2 = CryptoMiner.FactorizationAsync(y);
            Task.WaitAll(ares1, ares2);
            benchmark.Stop();

            Console.Write("First number: ");
            foreach (var an in ares1.Result)
            {
                Console.Write(an + " ");
            }
            Console.WriteLine();

            Console.Write("Second number: ");
            foreach (var an1 in ares2.Result)
            {
                Console.Write(an1 + " ");
            }

            Console.WriteLine($"\nMultiThread = {benchmark.ElapsedMilliseconds} ms");

            Console.WriteLine("\nWaiting for GCD result..");

            benchmark.Restart();
            var gcd = await CryptoMiner.GCD(x, y);
            benchmark.Stop();

            Console.WriteLine($"GCD calculation time = {benchmark.ElapsedMilliseconds} ms");
            Console.WriteLine($"GCD = {gcd}");
        }
    }
}
