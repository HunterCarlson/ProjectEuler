using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _10_Summation_of_Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            //The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
            //
            //Find the sum of all the primes below two million.

            long sum = 0;
            List<int> primes = MathFunctions.PrimesBelowN(2000000);
            foreach (int prime in primes)
            {
                sum += prime;
            }

            Console.WriteLine(primes.Count + " primes");
            Console.WriteLine("sum of primes: " + sum);
            Console.Read();

        }
    }
}
