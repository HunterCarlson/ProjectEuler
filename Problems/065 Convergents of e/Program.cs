using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _065_Convergents_of_e
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NthNumeratorOfContFractOfE(100));
            Console.WriteLine(MathFunctions.DigitSum(NthNumeratorOfContFractOfE(100)));

            Console.Read();
        }

        static int AOfK(int k)
        {
            if ( (k+1) % 3 == 0)
            {
                return k - k/3;
            }
            else
            {
                return 1;
            }
        }

        static BigInteger NthNumeratorOfContFractOfE(int n)
        {
            BigInteger nSub2 = 2;
            BigInteger nSub1 = 3;
            BigInteger numerator = 8;

            for (int i = 3; i < n; i++)
            {
                nSub2 = nSub1;
                nSub1 = numerator;
                numerator = AOfK(i)*nSub1 + nSub2;
            }
            return numerator;
        }
    }
}
