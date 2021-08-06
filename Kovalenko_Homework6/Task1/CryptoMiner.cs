using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Task1
{
    public static class CryptoMiner
    {
        // O(sqrt(n)) still slow :(
        public static List<BigInteger> Factorization(BigInteger number) 
        {
            if(number < 2)
            {
                throw new ArgumentException("Number must be natural");
            }

            var result = new List<BigInteger>();

            for (BigInteger i = 2; i <= Sqrt(number); i++)
            {
                while (number % i == 0)
                {
                    result.Add(i);
                    number /= i;
                }
            }

            if(number != 1)
            {
                result.Add(number);
            }

            return result;
        }

        public static Task<List<BigInteger>> FactorizationAsync(BigInteger number) 
        {
            var tcs = new TaskCompletionSource<List<BigInteger>>();
            new Thread(Calculation).Start();
            return tcs.Task;

            void Calculation()
            {
                try
                {
                    var result = Factorization(number);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }

        public static async ValueTask<BigInteger> GCD(BigInteger first, BigInteger second)// use factorization async there
        {
            if (first <= 0 || second <= 0)
            {
                throw new ArgumentException("Arguments must be greater than 1");
            }

            if (first == 1 || second == 1) return 1;

            var f1 = FactorizationAsync(first);
            var f2 = FactorizationAsync(second);
            var res = await Task.WhenAll(f1, f2);
            
            var intersect = res[0].Where(x => res[1].Remove(x));

            BigInteger gcd = 1;
            foreach(var num in intersect)
            {
                gcd *= num;
            }

            return gcd;
        }

        private static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!IsSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }
            throw new ArgumentException("must be greater than 0");
        }

        private static bool IsSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }
    }
}
