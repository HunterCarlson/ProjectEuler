using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _057_Square_root_convergents
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //It is possible to show that the square root of two can be expressed as an infinite continued fraction.

            //√ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...

            //By expanding this for the first four iterations, we get:

            //1 + 1/2 = 3/2 = 1.5
            //1 + 1/(2 + 1/2) = 7/5 = 1.4
            //1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
            //1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...

            //The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 
            //1393/985, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.

            //In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?


            int count = 0;
            int limit = 1000;
            List<BigInteger[]> fractions = NFractionalExpansionsOfRootTwo(limit);
            for (int i = 0; i < fractions.Count; i++)
            {
                //Console.WriteLine("{0}th expansion = {1}/{2}", i, fractions[i][0], fractions[i][1]);
                int numeratorDigits = fractions[i][0].ToString().Length;
                int denomDigits = fractions[i][1].ToString().Length;
                if (numeratorDigits > denomDigits)
                {
                    count++;
                }
            }
            Console.WriteLine("there are {0} fractions under {1}", count, limit);

            Console.Read();
        }

        public static List<BigInteger[]> NFractionalExpansionsOfRootTwo(int n)
        {
            var fractions = new List<BigInteger[]>();
            fractions.Add(new BigInteger[] {1, 1});
            fractions.Add(new BigInteger[] {3, 2});
            fractions.Add(new BigInteger[] {7, 5});
            //for numerator:
            //n(x) = n(x-1)*2 + n(x-2)
            for (int i = 3; i <= n; i++)
            {
                BigInteger numerator = fractions[i - 1][0]*2 + fractions[i - 2][0];
                BigInteger denominator = fractions[i - 1][1]*2 + fractions[i - 2][1];
                if (numerator < 0 || denominator < 0)
                {
                    throw new Exception("overflow! use bigger data type");
                }
                fractions.Add(new[] {numerator, denominator});
            }
            return fractions;
        }
    }
}