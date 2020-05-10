using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _040_Champernownes_constant
{
    class Program
    {
        static void Main(string[] args)
        {
            //An irrational decimal fraction is created by concatenating the positive integers:

            //0.12345678910[1]112131415161718192021...

            //It can be seen that the 12th digit of the fractional part is 1.

            //If dn represents the nth digit of the fractional part, find the value of the following expression.

            //d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000

            int product = 1;
            for (int j = 0; j <= 6; j++)
            {
                int n = (int)Math.Pow(10, j);
                int digit = NthDigitOfChampernowne(n);
                Console.WriteLine("The {0}th digit is {1}", n, digit);
                product *= digit;
            }
            Console.WriteLine("product = {0}", product);

            Console.Read();
        }

        public static int NthDigitOfChampernowne(int n)
        {
            int digit = 1;
            int number = 1;
            while (digit < n)
            {
                digit += number.ToString().Length;
                number++;
            }
            string temp = number.ToString();
            return int.Parse(temp[digit - n].ToString());
        }

    }
}
