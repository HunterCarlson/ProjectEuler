using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _063_Powerful_digit_counts
{
    class Program
    {
        static void Main(string[] args)
        {
            //The 5-digit number, 16807=7^5, is also a fifth power. 
            //Similarly, the 9-digit number, 134217728=8^9, is a ninth power.

            //How many n-digit positive integers exist which are also an nth power?

            /*Notes:
             * 
             * 9^22 is limit - only 21 digits
             */

            int powerLimit = 22;

            long count = 0;
            for (int exponent = 1; exponent < powerLimit; exponent++)
            {
                for (int x = 1; x < 10; x++)
                {
                    BigInteger number = MathFunctions.XToPowerN(x, exponent);
                    if (number.ToString().Length == exponent)
                    {
                        count++;
                        //Console.WriteLine("{0}^{1} = {2}", x, exponent, number );
                    }
                }
            }
            Console.WriteLine(count);


            Console.Read();
        }

    }
}
