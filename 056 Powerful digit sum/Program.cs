using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _056_Powerful_digit_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //A googol (10^100) is a massive number: one followed by one-hundred zeros; 
            //100^100 is almost unimaginably large: one followed by two-hundred zeros. 
            //Despite their size, the sum of the digits in each number is only 1.

            //Considering natural numbers of the form, a^b, where a, b < 100, what is the maximum digital sum?

            /* Notes:
             * 
             * a can't end in 0 and be max - lots of zeroes at the end
             */

            Console.WriteLine(MathFunctions.DigitSum(123456789));

            BigInteger test = MathFunctions.PowBigInteger(100, 100);
            Console.WriteLine(test);
            Console.WriteLine(MathFunctions.DigitSum(test));

            BigInteger maxDigitSum = 0;

            const int maxNum = 100;
            for (int a = 2; a < maxNum; a++)
            {
                BigInteger currentProduct = a;
                for (int b = 2; b < maxNum; b++)
                {
                    currentProduct *= a;
                    BigInteger digitSum = MathFunctions.DigitSum(currentProduct);
                    if (digitSum > maxDigitSum)
                    {
                        maxDigitSum = digitSum;
                    }
                }
            }
            Console.WriteLine(maxDigitSum);


            Console.Read();
        }
    }
}
