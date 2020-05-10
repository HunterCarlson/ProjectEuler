using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _041_Pandigital_prime
{
    class Program
    {
        static void Main(string[] args)
        {
            //We shall say that an n-digit number is pandigital if it makes use of 
            //all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.

            //What is the largest n-digit pandigital prime that exists?

            Console.WriteLine(IsPandigitalPrime(2143));

            //7 digit pandigital is most digits that can still be prime
            //1+2+3+4+5+6+7+8+9 = 45 => is divisible by 3 => not prime
            //1+2+3+4+5+6+7+8 = 36 => is divisible by 3 => not prime
            //1+2+3+4+5+6+7 = 28 => NOT divisible by 3 => can be prime
            const int limit = 7654321;

            int LargestPandigitalPrime = 0;

            for (int i = 10; i < limit; i++)
            {
                if (IsPandigitalPrime(i))
                {
                    LargestPandigitalPrime = i;
                }
            }
            Console.WriteLine(LargestPandigitalPrime);

            Console.Read();
        }

        public static bool IsPandigitalPrime(int n)
        {
            if (!MathFunctions.IsPandigital(n))
            {
                return false;
            }
            if (!MathFunctions.IsPrime(n))
            {
                return false;
            }
            return true;
        }
    }
}
