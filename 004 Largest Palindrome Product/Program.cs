using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_LargestPalindromeProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            //A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
            //Find the largest palindrome made from the product of two 3-digit numbers.

            int lpp = 0;
            int product;

            for (int i = 1; i < 999; i++)
            {
                for (int j = 1; j < 999; j++)
                {
                    product = i * j;

                    if (product.ToString() == Reverse(product.ToString()))     //if palindrome
                    {
                        if (product > lpp)
                        {
                            lpp = product;
                        }
                    }
                }
            }
            Console.WriteLine(lpp);
            Console.Read();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool isPalindrome(int n)
        {
            List<int> digits = new List<int>();
            while (n > 0)
            {
                digits.Add(n % 10);
                n = n / 10;
            }
            for (int i = 0; i < digits.Count / 2 + 1; i++)
            {
                if (digits[i] != digits[digits.Count - i - 1])
                {
                    return false;
                }
            }
            return true;

        }
    }
}
