using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _073_Counting_fractions_in_a_range
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consider the fraction, n/d, where n and d are positive integers. If n<d and HCF(n,d)=1, it is called a reduced proper fraction.

            //If we list the set of reduced proper fractions for d ≤ 8 in ascending order of size, we get:

            //1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8

            //It can be seen that there are 3 fractions between 1/3 and 1/2.

            //How many fractions lie between 1/3 and 1/2 in the sorted set of reduced proper fractions for d ≤ 12,000?

            /*Notes:
             * 
             * ReducedProperFractions(12000) = 43,772,257
             * range(1/3, 1/2) = 1/6
             * 43772257/6 = 7295376
             * there should be about 7,295,376
             * 
             */

            double min = 1.0/3;
            double max = 1.0/2;

            int count = 0;
            const int limit = 12000;

            for (int d = 2; d <= limit; d++)
            {
                for (int n = 1; n < d; n++)
                {
                    double fraction = (double) n/d;
                    if (fraction <= min || fraction >= max)
                    {
                        continue;
                    }

                    if (MathFunctions.GreatestCommonFactor(n, d) == 1)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);


            Console.Read();
        }
    }
}
