using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _036_Double_base_palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            //The decimal number, 585 = 1001001001(binary), is palindromic in both bases.

            //Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

            //(Please note that the palindromic number, in either base, may not include leading zeros.)

            int limit = 1000000;

            Console.WriteLine(IsDoubleBasePalindrome(585));

            List<int> doubleBasePalindromes = new List<int>();

            for (int i = 1; i < limit; i++)
            {
                if (IsDoubleBasePalindrome(i))
                {
                    doubleBasePalindromes.Add(i);
                }
            }
            Console.WriteLine(doubleBasePalindromes.Sum());



            Console.Read();
        }

        public static bool IsDoubleBasePalindrome(int n)
        {
            if (!IsPalindrome(n.ToString())) 
            {
                return false;
            }

            string binary = Convert.ToString(n, 2);     //convert decimal to binary
            if (!IsPalindrome(binary))
            {
                return false;
            }
            return true;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool IsPalindrome(string s)
        {
            string forward = s.ToString();
            string backward = Reverse(forward);
            if (forward == backward)  //if palindrome
            {
                return true;
            }
            return false;
        }

    }
}
