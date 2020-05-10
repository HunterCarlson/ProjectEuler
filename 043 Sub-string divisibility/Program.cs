using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;
using System.Numerics;

namespace _043_Sub_string_divisibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order,
            //but it also has a rather interesting sub-string divisibility property.

            //Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

            //    d2d3d4=406 is divisible by 2
            //    d3d4d5=063 is divisible by 3
            //    d4d5d6=635 is divisible by 5
            //    d5d6d7=357 is divisible by 7
            //    d6d7d8=572 is divisible by 11
            //    d7d8d9=728 is divisible by 13
            //    d8d9d10=289 is divisible by 17

            //Find the sum of all 0 to 9 pandigital numbers with this property.


            //go thru all pandigitals

            //10! combinations

            List<int> nums = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] test = MathFunctions.NthPermuatation(1494151, nums).ToArray();
            foreach (var item in test)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine(MathFunctions.DigitArrayToInt(test));

            int test1 = 1234567890;
            int test2 = 1406357289;
            long test3 = 4106357289;

            Console.WriteLine(test3 % 10);

            Console.WriteLine(IsSubstringPrimeDivisible(test1));
            Console.WriteLine(IsSubstringPrimeDivisible(test2));
            Console.WriteLine(IsSubstringPrimeDivisible(test3));

            BigInteger sum = 0;
            int permutation;
            int permLimit = 3628800;
            
            List<long> primeDivPans = new List<long>();
            List<int> permIndexes = new List<int>();
            for (permutation = 1; permutation < permLimit + 1; permutation++)
            {
                int[] n =MathFunctions.NthPermuatation(permutation, nums).ToArray();
                if (IsSubstringPrimeDivisible(n))
                {
                    long pdPan = MathFunctions.DigitArrayToInt(n);
                    primeDivPans.Add(pdPan);
                    sum += pdPan;
                    permIndexes.Add(permutation);
                }
            }
            Console.WriteLine("there are {0} numbers ", primeDivPans.Count);
            Console.WriteLine("for a sum of {0}", sum);

            for (int i = 0; i < primeDivPans.Count; i++)
			{
                Console.WriteLine("permutaion {0} is {1}", permIndexes[i], primeDivPans[i]);
			}

            Console.Read();
        }

        public static bool IsSubstringPrimeDivisible(long n)
        {
            if (n.ToString().Length < 10)       //first digit was zero and got truncated
            {
                return false;
            }

            int[] primes = {1, 2, 3, 5, 7, 11, 13, 17};
            int[] number = MathFunctions.IntToDigitArray(n);

            for (int i = 1; i < primes.Length; i++)
			{
                int prime = primes[i];
                int subSeq = number[i]*100 + number[i+1]*10 + number[i+2];
                //Console.WriteLine("{0} % {1} = {2}", subSeq, prime, subSeq % prime);
			    if (subSeq % prime != 0)
	            {
		            return false;
	            }
			}
            return true;
        }

        public static bool IsSubstringPrimeDivisible(int[] n)
        {
            if (n.Length < 10)       //first digit was zero and got truncated
            {
                return false;
            }

            int[] primes = { 1, 2, 3, 5, 7, 11, 13, 17 };
            int[] number = new int[10];
            Array.Copy(n, number, n.Length);

            for (int i = 1; i < primes.Length; i++)
            {
                int prime = primes[i];
                int subSeq = number[i] * 100 + number[i + 1] * 10 + number[i + 2];
                //Console.WriteLine("{0} % {1} = {2}", subSeq, prime, subSeq % prime);
                if (subSeq % prime != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
