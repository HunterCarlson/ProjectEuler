using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _077_Prime_summations
{
    class Program
    {
        static void Main(string[] args)
        {
            //It is possible to write ten as the sum of primes in exactly five different ways:

            //7 + 3
            //5 + 5
            //5 + 3 + 2
            //3 + 3 + 2 + 2
            //2 + 2 + 2 + 2 + 2

            //What is the first value which can be written as the sum of primes in over five thousand different ways?

            const int limit = 1000000;

            var primes = MathFunctions.ESieve(limit);

            int ways = 0;
            int value = 10;

            while (ways < 5000)
            {
                value++;
                ways = WaysToWriteAsSumOfPrimes(value, primes);
            }
            Console.WriteLine("{0} can be written as the sum of primes {1} ways", value, ways);

            Console.Read();
        }
        public static int WaysToWriteAsSumOfPrimes(int target, int[] primes)
        {
            int[] ways = new int[target + 1];
            ways[0] = 1;

            foreach (int prime in primes)
            {
                for (int i = prime; i <= target; i++)
                {
                    ways[i] += ways[i - prime];
                }
            }
            return ways[target];
        }
    }
}
