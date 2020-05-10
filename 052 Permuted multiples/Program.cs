using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _052_Permuted_multiples
{
    class Program
    {
        static void Main(string[] args)
        {
            //It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

            //Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.

            var watch = Stopwatch.StartNew();


            for (int i = 1; i < int.MaxValue; i++)
            {
                if (MultiplesHaveSameDigits(i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("{0} ms ellapsed", elapsedMs);

            Console.Read();
        }

        static bool MultiplesHaveSameDigits(int n)
        {
            for (int i = 2; i <= 6; i++)
            {
                if (!MathFunctions.IsPermutationOf(i*n, n))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
