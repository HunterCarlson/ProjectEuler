using System;
using System.Collections.Generic;
using MyMathFunctions;

namespace _087_Prime_power_triples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //The smallest number expressible as the sum of a prime square, prime cube, and prime fourth power is 28. 
            //In fact, there are exactly four numbers below fifty that can be expressed in such a way:

            //2^8 = 2^2 + 2^3 + 2^4
            //3^3 = 3^2 + 2^3 + 2^4
            //4^9 = 5^2 + 2^3 + 2^4
            //4^7 = 2^2 + 3^3 + 2^4

            //How many numbers below fifty million can be expressed as the sum of a prime square, prime cube, and prime fourth power?

            int limit = 50000000;
            var b2primeLimit = (int) Math.Floor(Math.Pow(limit, (1.0/2)));
            int[] b2primes = MathFunctions.ESieve(b2primeLimit);
            var b3primeLimit = (int) Math.Floor(Math.Pow(limit, (1.0/3)));
            int[] b3primes = MathFunctions.ESieve(b3primeLimit);
            var b4primeLimit = (int) Math.Floor(Math.Pow(limit, (1.0/4)));
            int[] b4primes = MathFunctions.ESieve(b4primeLimit);

            //hashset only hold unique items - no duplicates
            HashSet<int> sums = new HashSet<int>();

            for (int i = 0; i < b2primes.Length; i++)
            {
                for (int j = 0; j < b3primes.Length; j++)
                {
                    for (int k = 0; k < b4primes.Length; k++)
                    {
                        int b2 = b2primes[i];
                        int b3 = b3primes[j];
                        int b4 = b4primes[k];
                        int sum = MathFunctions.PowInt(b2, 2) + MathFunctions.PowInt(b3, 3) +
                                  MathFunctions.PowInt(b4, 4);
                        if (sum < limit)
                        {
                            sums.Add(sum);
                            //Console.WriteLine(sum);
                        }
                    }
                }
                Console.WriteLine("{0} / {1}", i, b2primes.Length);
            }
            Console.WriteLine(sums.Count);

            Console.Read();
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write("{0}, ", item);
            }
        }
    }
}