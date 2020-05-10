using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _016_Power_Digit_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

            //What is the sum of the digits of the number 2^1000?

            BigInteger sum = 0;
            BigInteger number;
            const int exponent = 1000;

            number = 2;
            for (int i = 1; i < exponent; i++)
            {
                number = number * 2;
            }

            BigInteger temp = number;
            while (temp > 0)
            {
                sum += temp % 10;
                temp = temp / 10;
            }

            Console.WriteLine("2^{0} = {1}", exponent, number);
            Console.WriteLine("the digits of 2^{0} sum to {1}", exponent, sum);
            Console.Read();
        }
    }
}
