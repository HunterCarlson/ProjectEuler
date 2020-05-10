using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _051_Prime_digit_replacements_Better
{
    class Program
    {
        const string ZeroThruNine = "0123456789";

        static void Main(string[] args)
        {
            //By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 
            //13, 23, 43, 53, 73, and 83, are all prime.

            //By replacing the 3rd and 4th digits of 56**3 with the same digit, 
            //this 5-digit number is the first example having seven primes among the ten generated numbers, 
            //yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, 
            //being the first member of this family, is the smallest prime with this property.

            //Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) 
            //with the same digit, is part of an eight prime value family.


            /* notes
             * 
             * 8 member family
             * 
             * looking for smallest number with 8 member family, so there must be 7 higher than the smallest in the family
             * with possible digits [0, 9] - 7 = [0, 2]
             * so 0, 1, 2 are the possible repeated digits in the smallest number
             * 
             * digits have to be replaced in groups of 3
             * so sum of added digits is divisible by three
             * so it increments the number in such a way that if it is not %3 it stays not %3
             * otherwise, it would increment in %3=1 or %3=2 which results in 3 results being %3
             * 3 results of 10 = 7
             * 7 < 8
             * so can't be anything other than groupings of multiples of 3
             * 
             */

            var watch = Stopwatch.StartNew();

            int[] primes = MathFunctions.ESieve(1000000);
            string digitsToRepeat = "012";
            
            int[] timesToRepeat = {3, 6, 9};

            foreach (int prime in primes)
            {
                if (prime < 100000)  //should be > 5 digits
                {
                    continue;
                }
                string numString = prime.ToString();
                //repeated digit is 0, 1, or 2
                //repeated digit is repeated 3, 6, or 9 times
                bool hasCorrectRepDigits = false;
                char repeatedDigit = '\0';
                foreach (var repeatDigit in digitsToRepeat)
                {
                    int digitCount = 0;
                    foreach (var primeDigit in numString)
                    {
                        if (primeDigit == repeatDigit)
                        {
                            digitCount++;
                        }
                    }
                    if (timesToRepeat.Contains(digitCount))
                    {
                        hasCorrectRepDigits = true;
                        repeatedDigit = repeatDigit;
                    }
                }
                if (hasCorrectRepDigits)
                {
                    //test if prime is member of 8 member family
                    if (IsPartOf8MemeberFamily(numString, repeatedDigit))
                    {
                        Console.WriteLine(numString);
                        break;
                    }
                }
            }



            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("{0} ms ellapsed", elapsedMs);

            Console.Read();
        }

        static bool IsPartOf8MemeberFamily(string numString, char repeatedDigit)
        {
            int notFamilyCount = 0;
            foreach (var digit in ZeroThruNine)
            {
                string temp = string.Copy(numString).Replace(repeatedDigit, digit);
                if (temp[0] == '0' || !MathFunctions.IsPrime(int.Parse(temp)))       //check for leading zeroes
                {
                    notFamilyCount++;
                }
                if (notFamilyCount > 2)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
