using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _035_Circular_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            //The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

            //There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

            //How many circular primes are there below one million?

            Console.WriteLine(IsCircularPrime(197));
            Console.WriteLine(IsCircularPrime(2));
            Console.WriteLine(IsCircularPrime(101));

            const int limit = 1000000;
            int count = 0;

            for (int i = 2; i < limit; i++)
            {
                if (IsCircularPrime(i))
                {
                    count++;
                    Console.WriteLine(i);
                }
                //Console.WriteLine("iteration " + i);
            }
            Console.WriteLine("there are {0} circular primes below {1}", count, limit);

            Console.Read();
        }

        public static void RotateArray(int[] array)
        {
            //Array.Reverse(array, 0, 1);
            Array.Reverse(array, 1, array.Length - 1);
            Array.Reverse(array);
        }

        public static bool IsCircularPrime(int n)
        {
            long temp;
            int[] digitArray = MathFunctions.IntToDigitArray(n);


            do
            {
                temp = MathFunctions.DigitArrayToInt(digitArray);
                if (!MathFunctions.BigIsPrime(temp))
                {
                    return false;
                }
                RotateArray(digitArray);
                temp = MathFunctions.DigitArrayToInt(digitArray);
            } while (temp != n);

            return true;
        }
    }
}
