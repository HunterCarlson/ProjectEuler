using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;


namespace _027_Quadratic_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Euler discovered the remarkable quadratic formula:

            //n² + n + 41

            //It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. 
            //However, when n = 40, 40² + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, 
            //and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.

            //The incredible formula  n² − 79n + 1601 was discovered, 
            //which produces 80 primes for the consecutive values n = 0 to 79. 
            //The product of the coefficients, −79 and 1601, is −126479.

            //Considering quadratics of the form:

            //    n² + an + b, where |a| < 1000 and |b| < 1000

            //    where |n| is the modulus/absolute value of n
            //    e.g. |11| = 11 and |−4| = 4

            //Find the product of the coefficients, a and b, 
            //for the quadratic expression that produces the maximum number of primes 
            //for consecutive values of n, starting with n = 0.

            Console.WriteLine(QuadPrimesCount(1, 41));
            Console.WriteLine(QuadPrimesCount(-79, 1601));

            Console.WriteLine(QuadPrimesCount(-999, 61));

            int maxPrimeCount = 0;
            int maxA = 0;
            int maxB = 0;
            for (int a = -999; a < 1000; a++)
            {
                for (int b = -999; b < 1000; b++)
                {
                    int primeCount = QuadPrimesCount(a, b);
                    if (primeCount > maxPrimeCount)
                    {
                        maxPrimeCount = primeCount;
                        maxA = a;
                        maxB = b;
                    }
                }
                Console.WriteLine("iteration {0}", a);
                Console.WriteLine("a={0} b={1} produces {2} primes", maxA, maxB, maxPrimeCount);
            }
            Console.WriteLine("Final Result:");
            Console.WriteLine("a={0} b={1} produces {2} primes", maxA, maxB, maxPrimeCount);

            Console.Read();

        }

        public static int QuadraticPrimeEquation(int n, int a, int b)
        {
            return (n * n) + (a * n) + b;
        }

        public static int QuadPrimesCount(int a, int b)
        {
            int count = 0;
            int result;

            do
            {
                result = QuadraticPrimeEquation(count, a, b);
                count++;
            } while (MathFunctions.IsPrime(result));
            return count - 1;
        }

    }
}
