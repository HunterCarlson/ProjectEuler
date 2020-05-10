using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _030_Digit_fifth_powers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*   
            Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

               1634 = 1^4 + 6^4 + 3^4 + 4^4
               8208 = 8^4 + 2^4 + 0^4 + 8^4
               9474 = 9^4 + 4^4 + 7^4 + 4^4

            As 1 = 1^4 is not a sum it is not included.

            The sum of these numbers is 1634 + 8208 + 9474 = 19316.

            Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
            */
            

            //start at 10, as 1 digit numbers cant have a sum



            Console.Read();
        }

        public static bool IsSumOfNthPowersOfDigts(int n, int power)
        {
            int sum = 0;



            if (n == sum)
            {
                return true;
            }
            return false;
        }
    }
}
