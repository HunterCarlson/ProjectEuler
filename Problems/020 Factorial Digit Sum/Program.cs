using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MyMathFunctions;

namespace _020_Factorial_Digit_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //n! means n × (n − 1) × ... × 3 × 2 × 1

            //For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
            //and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

            //Find the sum of the digits in the number 100!

            BigInteger factorial = MathFunctions.Factorial(100);
            int sum = 0;
            while (factorial > 0)
            {
                Console.WriteLine((factorial % 10));
                sum += (int)(factorial % 10);
                factorial = factorial / 10;
            }

            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
