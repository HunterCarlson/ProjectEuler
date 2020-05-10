using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _080_Square_root_digital_expansion
{
    class Program
    {
        static void Main(string[] args)
        {
            //It is well known that if the square root of a natural number is not an integer, then it is irrational. 
            //The decimal expansion of such square roots is infinite without any repeating pattern at all.

            //The square root of two is 1.41421356237309504880..., and the digital sum of the first one hundred decimal digits is 475.

            //For the first one hundred natural numbers, 
            //find the total of the digital sums of the first one hundred decimal digits for all the irrational square roots.

            var test = MathFunctions.FirstNDigitsOfSqrt(2, 100);
            foreach (int i in test)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine(test.Sum());
            Debug.Assert(test.Length == 100);
            Debug.Assert(test.Sum() == 475);

            const int digits = 100;
            int sum = 0;
            for (int i = 1; i < 100; i++)
            {
                if (!MathFunctions.IsSquare(i))
                {
                    int[] first100Digits = MathFunctions.FirstNDigitsOfSqrt(i, digits);
                    sum += first100Digits.Sum();
                }
            }
            Console.WriteLine(sum);

            Console.Read();
        }
    }
}
