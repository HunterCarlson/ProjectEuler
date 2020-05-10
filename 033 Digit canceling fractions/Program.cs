using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033_Digit_canceling_fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            //The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it 
            //may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

            //We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

            //There are exactly four non-trivial examples of this type of fraction, less than one in value, 
            //and containing two digits in the numerator and denominator.

            //If the product of these four fractions is given in its lowest common terms, find the value of the denominator.

            int numerator = 49;
            int denominator = 98;

            decimal fraction = (decimal)numerator / denominator;

            Console.WriteLine(fraction);

            int n10, n1;
            int d10, d1;

            n10 = numerator / 10;
            n1 = numerator % 10;

            d10 = denominator / 10;
            d1 = denominator % 10;


            Console.WriteLine("{0}{1} / {2}{3}", n10, n1, d10, d1);

            Console.WriteLine(IsDigitCancellingFraction(49, 98));


            List<int> numerators = new List<int>();
            List<int> denominators = new List<int>();

            for (int i = 10; i < 100; i++)
            {
                for (int j = 10; j < 100; j++)
                {
                    if (i < j)   //for fractions less than 1
                    {
                        if (IsDigitCancellingFraction(i, j))
                        {
                            Console.WriteLine("{0} / {1}", i, j);
                            numerators.Add(i);
                            denominators.Add(j);
                        }
                    }
                }
            }

            int numProduct = 1;
            foreach (int n in numerators)
            {
                numProduct *= n;
            }
            int denomProduct = 1;
            foreach (int n in denominators)
            {
                denomProduct *= n;
            }

            Console.WriteLine("product = {0} / {1}", numProduct, denomProduct);
            

            Console.Read();
        }

        public static bool IsDigitCancellingFraction(int numerator, int denominator)
        {
            decimal fraction = (decimal)numerator / denominator;

            int n10, n1;
            int d10, d1;

            n10 = numerator / 10;
            n1 = numerator % 10;

            d10 = denominator / 10;
            d1 = denominator % 10;

            if (n1 == 0 && d1 == 0)
            {
                return false;   //trivial case
            }

            int simplifiedNumerator;
            int simplifiedDenominator;
            decimal simplifiedFraction;

            if (n10 == d10)
            {
                simplifiedNumerator = n1;
                simplifiedDenominator = d1;
                if (simplifiedDenominator != 0)
                {
                    simplifiedFraction = (decimal)simplifiedNumerator / simplifiedDenominator;
                    if (fraction == simplifiedFraction)
                    {
                        return true;
                    } 
                }
            }
            if (n10 == d1)
            {
                simplifiedNumerator = n1;
                simplifiedDenominator = d10;
                if (simplifiedDenominator != 0)
                {
                    simplifiedFraction = (decimal)simplifiedNumerator / simplifiedDenominator;
                    if (fraction == simplifiedFraction)
                    {
                        return true;
                    } 
                }
            }
            if (n1 == d10)
            {
                simplifiedNumerator = n10;
                simplifiedDenominator = d1;
                if (simplifiedDenominator != 0)
                {
                    simplifiedFraction = (decimal)simplifiedNumerator / simplifiedDenominator;
                    if (fraction == simplifiedFraction)
                    {
                        return true;
                    }
                }
                
            }
            if (n1 == d1)
            {
                simplifiedNumerator = n10;
                simplifiedDenominator = d10;
                if (simplifiedDenominator != 0)
                {
                    simplifiedFraction = (decimal)simplifiedNumerator / simplifiedDenominator;
                    if (fraction == simplifiedFraction)
                    {
                        return true;
                    } 
                }
            }
            return false;

        }

    }
}
