using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _7_10001stPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            //By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            //
            //What is the 10 001st prime number?

            const int n = 10001;
            Console.WriteLine(MathFunctions.NthPrime(n));
            Console.Read();

        }

    }
}
