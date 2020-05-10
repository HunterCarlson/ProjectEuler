using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _034_Digit_factorials
{
    class Program
    {
        static void Main(string[] args)
        {
            //145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

            //Find the sum of all numbers which are equal to the sum of the factorial of their digits.

            //Note: as 1! = 1 and 2! = 2 are not sums they are not included.


            //use an array instead of math as only doing factoral of 0-9

            Console.WriteLine(IsFactorialOfDigits(145));
            int limit = 10000000;
            List<int> digitFactorials = new List<int>();

            for (int i = 10; i < limit; i++)
            {
                if (IsFactorialOfDigits(i))
                {
                    Console.WriteLine(i);
                    digitFactorials.Add(i);
                }
            }

            Console.WriteLine("there are {0} numbers equal to the sum of the factorials of their digits", digitFactorials.Count);

            Console.Read();

        }

        public static bool IsFactorialOfDigits(int n)
        {
            int[] factorial = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            List<int> digits = new List<int>();
            int temp = n;
            while (temp > 0)
            {
                int digit = temp % 10;
                digits.Add(digit);
                temp = temp / 10;
            }

            int sum = 0;
            foreach (int digit in digits)
            {
                sum += factorial[digit];
            }

            if (sum == n)
            {
                return true;
            }
            return false;
        }
    }
}
