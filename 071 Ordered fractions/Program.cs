using System;

namespace _071_Ordered_fractions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Consider the fraction, n/d, where n and d are positive integers. 
            //If n<d and HCF(n,d)=1, it is called a reduced proper fraction.

            //If we list the set of reduced proper fractions for d ≤ 8 in ascending order of size, we get:

            //1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8

            //It can be seen that 2/5 is the fraction immediately to the left of 3/7.

            //By listing the set of reduced proper fractions for d ≤ 1,000,000 in ascending order of size, 
            //find the numerator of the fraction immediately to the left of 3/7.

            /*Notes
             * 
             * MathFunctions.GreatestCommonFactor();
             * 
             * biggest n/d where n<d and n/d < 3/7 and d<=1000000
             */

            int limit = 1000000;
            double goal = 3.0/7;

            double closestToGoal = 0;
            int closestN = 0;
            int closestD = 0;

            int count = 0;

            for (int d = 0; d < limit; d++)
            {
                var n = (int) Math.Floor(3.0/7*d);
                double fraction = (double) n/d;
                //if fraction == goal, the fraction simplified to the goal, so decrease the numerator by 1 to get the next closest
                if (fraction == goal)
                {
                    n = n - 1;
                    fraction = (double) n/d;
                }
                if (fraction > closestToGoal)
                {
                    closestToGoal = fraction;
                    closestN = n;
                }
            }
            Console.WriteLine("Answer: {0}", closestN);
            Console.Read();
        }
    }
}