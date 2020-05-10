using System;
using System.Collections.Generic;
using MyMathFunctions;

namespace _058_Spiral_primes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed.

            //37 36 35 34 33 32 31
            //38 17 16 15 14 13 30
            //39 18  5  4  3 12 29
            //40 19  6  1  2 11 28
            //41 20  7  8  9 10 27
            //42 21 22 23 24 25 26
            //43 44 45 46 47 48 49

            //It is interesting to note that the odd squares lie along the bottom right diagonal, but what is more interesting 
            //is that 8 out of the 13 numbers lying along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%.

            //If one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will be formed. 
            //If this process is continued, what is the side length of the square spiral for which the ratio of primes along both diagonals 
            //first falls below 10%?


            int answer = LessThan10PercentPrimeDiagonals();
            Console.WriteLine(answer);

            Console.Read();
        }

        public static int LessThan10PercentPrimeDiagonals()
        {
            var diags = new List<int>();
            var primeDiags = new List<int>();
            double percent;
            int skip = 1;
            int n = 1;
            int count = 0;
            while (true)
            {
                diags.Add(n);
                if (MathFunctions.IsPrime(n))
                {
                    primeDiags.Add(n);
                }
                count++;
                n += skip + 1;
                if (count%4 == 0)
                {
                    percent = (double) primeDiags.Count/diags.Count*100;
                    if (percent < 10)
                    {
                        break;
                    }
                    skip += 2;
                }
            }
            diags.Add(n);
            if (MathFunctions.IsPrime(n))
            {
                primeDiags.Add(n);
            }
            percent = (double) primeDiags.Count/diags.Count*100;
            Console.WriteLine("for a size {0} spiral {1}/{2} diags are prime, or {3}%", skip, primeDiags.Count,
                diags.Count, percent);

            return skip;
        }
    }
}