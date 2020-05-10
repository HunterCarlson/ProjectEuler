using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _070_Totient_permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Euler's Totient function, φ(n) [sometimes called the phi function], is used to determine the number of positive numbers less than or equal to n which are relatively prime to n. For example, as 1, 2, 4, 5, 7, and 8, are all less than nine and relatively prime to nine, φ(9)=6.
            //The number 1 is considered to be relatively prime to every positive number, so φ(1)=1.

            //Interestingly, φ(87109)=79180, and it can be seen that 87109 is a permutation of 79180.

            //Find the value of n, 1 < n < 10^7, for which φ(n) is a permutation of n and the ratio n/φ(n) produces a minimum.

            const int limit = 10000000;

            double minRatio = double.MaxValue;
            int givesMinRatio = 0;

            for (int i = 2; i < limit; i++)
            {
                int totient = MathFunctions.Totient(i);
                double ratio = (double)i/totient;
                if (ratio < minRatio && MathFunctions.IsPermutationOf(totient, i))
                {
                    minRatio = MathFunctions.PhiRatio(i);
                    givesMinRatio = i;
                    Console.WriteLine("φ({0}) = {1}", givesMinRatio, totient);
                    Console.WriteLine("n/φ = {0}", ratio);
                }
            }
            Console.WriteLine(givesMinRatio);

            Console.Read();
        }
    }
}
