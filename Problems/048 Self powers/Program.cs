using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _048_Self_powers
{
    class Program
    {
        static void Main(string[] args)
        {
            //The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.

            //Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.


            BigInteger sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                sum += BigInteger.Pow(i, i);
            }
            string numString = sum.ToString();
            string last10Digits = numString.Substring(numString.Length - 10);
            Console.WriteLine(last10Digits);

            Console.Read();
        }
    }
}
