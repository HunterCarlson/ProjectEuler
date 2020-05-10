using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MyMathFunctions;

namespace _072_Counting_fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consider the fraction, n/d, where n and d are positive integers. If n<d and HCF(n,d)=1, it is called a reduced proper fraction.

            //If we list the set of reduced proper fractions for d ≤ 8 in ascending order of size, we get:

            //1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8

            //It can be seen that there are 21 elements in this set.

            //How many elements would be contained in the set of reduced proper fractions for d ≤ 1,000,000?


            /*Notes:
             * 
             *      d <= n  |   proper fractions    |   possible fractions
             *       2              1                   1
             *       3              3                   3
             *       4              5                   6
             *       5              9                   10
             *       6              11                  15
             *       7              17                  21
             *       8              21                  28
             *       9              27                  36
             *       10             31                  45
             *       100            3043                4950
             *       1000           304191              499500
             *       10000          30397485            49995000
             *       
             * 
             *      possible fractions = 1/2 * (n-1) * (n)
             *           
             * 
             * proper fraction is sum of totients up to n
             */

            Stopwatch timer = new Stopwatch();
            timer.Start();


            int limit = 1000000;
            int[] phi = MathFunctions.PhiSieve(limit);

            long count = 0;
            for (int i = 2; i <= limit; i++)
            {
                count += phi[i];
            }
            

            timer.Stop();
            Console.WriteLine(count);
            Console.WriteLine("took {0} ms", timer.ElapsedMilliseconds);

            Console.Read();
        }
    }
}
