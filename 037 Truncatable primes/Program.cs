using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _037_Truncatable_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            //The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

            //Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

            //NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

            const int NumberOfTruncPrimes = 11;
            int TruncPrimeCount = 0;

            int test = 3797;
            int truncLeft = test;
            int truncRight = test;

            while (truncLeft > 0)
            {
                Console.WriteLine(truncLeft);
                truncLeft = TruncateLeft(truncLeft);
            }
            while (truncRight > 0)
            {
                Console.WriteLine(truncRight);
                truncRight = TruncateRight(truncRight);
            }


            int i = 10;
            List<int> TruncPrimes = new List<int>();
            Console.WriteLine("Truncatable Primes:");
            while (TruncPrimeCount < NumberOfTruncPrimes)
            {
                if (IsTruncPrime(i))
                {
                    TruncPrimes.Add(i);
                    Console.WriteLine(i);
                    TruncPrimeCount++;
                }
                i++;
            }

            Console.WriteLine("sum to {0}", TruncPrimes.Sum());




            Console.Read();
        }

        public static int TruncateLeft(int n)
        {
            string number = n.ToString();
            number = number.Substring(1);
            //int truncNum = int.Parse(number);
            int truncNum;
            int.TryParse(number, out truncNum);
            return truncNum;
        }
        public static int TruncateRight(int n)
        {
            return n / 10;
        }

        public static bool IsTruncPrime(int n)
        {
            if (!MathFunctions.IsPrime(n))
            {
                return false;
            }

            int trunc = TruncateLeft(n);
            while (trunc > 0)
            {
                if (!MathFunctions.IsPrime(trunc))
                {
                    return false;
                }
                trunc = TruncateLeft(trunc);
            }

            trunc = TruncateRight(n);
            while (trunc > 0)
            {
                if (!MathFunctions.IsPrime(trunc))
                {
                    return false;
                }
                trunc = TruncateRight(trunc);
            }
            return true;
        }

    }
}
