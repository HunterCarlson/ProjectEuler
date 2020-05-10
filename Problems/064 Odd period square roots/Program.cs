using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _064_Odd_period_square_roots
{
    class Program
    {
        static void Main(string[] args)
        {
            //full problem at:
            //https://projecteuler.net/problem=64
            //The first ten continued fraction representations of (irrational) square roots are:

            //√2=[1;(2)], period=1
            //√3=[1;(1,2)], period=2
            //√5=[2;(4)], period=1
            //√6=[2;(2,4)], period=2
            //√7=[2;(1,1,1,4)], period=4
            //√8=[2;(1,4)], period=2
            //√10=[3;(6)], period=1
            //√11=[3;(3,6)], period=2
            //√12= [3;(2,6)], period=2
            //√13=[3;(1,1,1,1,6)], period=5

            //Exactly four continued fractions, for N ≤ 13, have an odd period.

            //How many continued fractions for N ≤ 10000 have an odd period?

            /*Notes
             * http://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Continued_fraction_expansion
             */

            int limit = 10000;
            int count = 0;

            for (int i = 2; i <= limit; i++)
            {
                if (PeriodOfContinuedFractionOfSqrt(i) % 2 == 1)        //if period is odd
                {
                    count++;
                }
            }
            Console.WriteLine(count);

            Console.Read();
        }

        static int PeriodOfContinuedFractionOfSqrt(int s)
        {
            if (MathFunctions.IsSquare(s))
            {
                return 0;
            }

            int a0 = (int)Math.Sqrt(s);

            int m = 0;
            int d = 1;
            int a = a0;

            int n = 0;

            while (true)
            {
                n++;
                m = d*a - m;
                d = (s - m*m) / d;
                a = (a0 + m) / d;
                if (a == 2 * a0)
                {
                    break;
                }
            }
            return n;
        }
    }
}
