using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MyMathFunctions;

namespace _066_Diophantine_equation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Consider quadratic Diophantine equations of the form:

            //x^2 – D*y^2 = 1

            //For example, when D=13, the minimal solution in x is 649^2 – 13×180^2 = 1.

            //It can be assumed that there are no solutions in positive integers when D is square.

            //By finding minimal solutions in x for D = {2, 3, 5, 6, 7}, we obtain the following:

            //3^2 – 2×2^2 = 1
            //2^2 – 3×1^2 = 1
            //9^2 – 5×4^2 = 1
            //5^2 – 6×2^2 = 1
            //8^2 – 7×3^2 = 1

            //Hence, by considering minimal solutions in x for D ≤ 7, the largest x is obtained when D=5.

            //Find the value of D ≤ 1000 in minimal solutions of x for which the largest value of x is obtained.

            /*Notes:
             * http://en.wikipedia.org/wiki/Convergent_%28continued_fraction%29
             */

            const int start = 2;
            const int end = 1000;

            IEnumerable<int> possibleD = Enumerable.Range(start, end - start).Where(x => !MathFunctions.IsSquare(x));
            int dMakesLargestX = 0;
            BigInteger largestX = 0;
            foreach (int d in possibleD)
            {
                BigInteger x = MinimalSolutionInX(d);
                if (x > largestX)
                {
                    largestX = x;
                    dMakesLargestX = d;
                }
            }
            Console.WriteLine(dMakesLargestX);


            Console.Read();
        }

        private static BigInteger MinimalSolutionInX(int d)
        {
            return PellFundamentalSolution(d)[0];
        }

        private static BigInteger[] PellFundamentalSolution(int s)
        {
            //http://en.wikipedia.org/wiki/Convergent_%28continued_fraction%29#Fundamental_recurrence_formulas

            if (MathFunctions.IsSquare(s))
            {
                throw new InvalidOperationException("Number can't be N perfect square");
            }

            var aSubI = new List<int>();
            var nSubI = new List<BigInteger>();
            var dSubI = new List<BigInteger>();

            var a0 = (int) Math.Sqrt(s);
            BigInteger nMinus1 = 1;
            BigInteger dMinus1 = 0;

            //0th iteration
            int i = 0;
            aSubI.Add(a0);
            nSubI.Add(aSubI[0]);
            dSubI.Add(1);

            int m = 0;
            int d = 1;
            int a = a0;

            //1st iteration
            i++;
            m = d*a - m;
            d = (s - m*m)/d;
            a = (a0 + m)/d;
            aSubI.Add(a);
            nSubI.Add(aSubI[1]*nSubI[1 - 1] + nMinus1);
            dSubI.Add(aSubI[1]*dSubI[1 - 1] + dMinus1);

            //continue iterations until soulution found
            while (nSubI[i]*nSubI[i] - s*dSubI[i]*dSubI[i] != 1)
            {
                i++;

                m = d*a - m;
                d = (s - m*m)/d;
                a = (a0 + m)/d;
                aSubI.Add(a);

                //  n(i) = a(i)*n(i-1) + n(i-2)
                nSubI.Add(aSubI[i]*nSubI[i - 1] + nSubI[i - 2]);
                //  d(i) = a(i)*d(i-1) + d(i-2)
                dSubI.Add(aSubI[i]*dSubI[i - 1] + dSubI[i - 2]);
            }
            return new[] {nSubI[i], dSubI[i]};
        }
    }
}