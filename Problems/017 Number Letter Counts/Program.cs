using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_Number_Letter_Counts
{
    class Program
    {
        static void Main(string[] args)
        {
            //If the numbers 1 to 5 are written out in words: one, two, three, four, five, 
            //then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

            //If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

            //NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) 
            //contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
            //The use of "and" when writing out numbers is in compliance with British usage.

            int sum = 0;
            const int limit = 1000;

            int testNum = 115;
            Console.WriteLine("{0} has {1} letters", testNum, LetterCount(testNum));


            for (int i = 1; i <= limit; i++)
            {
                sum += LetterCount(i);
                Console.WriteLine("{0} has {1} letters", i, LetterCount(i));
            }

            Console.WriteLine("the numbers from 1 to {0} contain {1} letters", limit, sum);
            Console.Read();
        }

        public static int LetterCount(int n)
        {
            int letterCount = 0;
            Dictionary<int, int> numberWords = new Dictionary<int, int>
                {
                    {1, 3}, {2, 3}, {3, 5}, {4, 4}, {5, 4}, {6, 3}, {7, 5}, {8, 5}, {9, 4},
                    {11, 6}, {12, 6}, {13, 8}, {14, 8}, {15, 7}, {16, 7}, {17, 9}, {18, 8}, {19, 8},
                    {10, 3}, {20, 6}, {30, 6}, {40, 5}, {50, 5}, {60, 5}, {70, 7}, {80, 6}, {90, 6},
                    {100, 7},
                    {1000, 11}
                };

            if (n < 10)     //1 - 9
            {
                letterCount = numberWords[n];
            }
            else if (n < 20)        //11 - 19
            {
                letterCount = numberWords[n];
            }
            else if (n < 100)       //20 - 99
            {
                int onesDigit = n % 10;
                int tensDigit = n - onesDigit;
                if (onesDigit == 0)     //if ends in xxx0
                {
                    letterCount = numberWords[tensDigit];
                }
                else
                {
                    letterCount = numberWords[tensDigit] + numberWords[onesDigit];
                }
            }
            else if (n < 1000)      //100-999
            {
                int onesAndTens = n % 100;
                int hundredsDigit = n / 100;

                if (onesAndTens == 0)       //if ends in xx00
                {
                    letterCount = numberWords[hundredsDigit] + numberWords[100];
                }
                else
                {
                    letterCount = numberWords[hundredsDigit] + numberWords[100] + 3 + LetterCount(onesAndTens);     //add 3 for the "and"
                }
            }
            else if (n == 1000)     //1000
            {
                letterCount = numberWords[1000];
            }

            if (letterCount == 0)
            {
                throw new InvalidOperationException("that number isn't specified in this method");
            }
            if (n > 1000)
            {
                throw new InvalidOperationException("LetterCount only takes numbers from 1-1000");
            }
            return letterCount;

        }
    }
}
