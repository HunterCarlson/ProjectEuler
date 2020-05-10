using MyMathFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _023_Non_abundant_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            //A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
            //For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

            //A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

            //As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, 
            //the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis,
            //it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
            //However, this upper limit cannot be reduced any further by analysis even though it is known that the 
            //greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

            //Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

            Console.WriteLine(MathFunctions.SumOfDivisors(12));
            Console.WriteLine(IsAbundant(12));
            

            const int abundantLimit = 28123;

            List<int> abundantNumbers = new List<int>();
            for (int i = 1; i < abundantLimit; i++)
            {
                if (IsAbundant(i))
                {
                    abundantNumbers.Add(i);
                }
            }

            //test to check it finds 24 as smallest abundant sum and 20161 is not
            int sas = 1;
            while (!IsAnAbundantSum(sas, abundantNumbers))
            {
                sas++;
            }
            Console.WriteLine(sas + " is the smallest AN");
            // end test


            List<int> NotAnAbundantSum = new List<int>();
            for (int i = 1; i < abundantLimit; i++)
			{
                if (!IsAnAbundantSum(i, abundantNumbers))
                {
                    NotAnAbundantSum.Add(i);
                    //Console.WriteLine("{0} is not the sum of 2 ANs", i);
                }
			}
            Console.WriteLine("there are {0} positive integers that are not the sum of 2 ANs", NotAnAbundantSum.Count);
            Console.WriteLine("{0} is the biggest", NotAnAbundantSum[NotAnAbundantSum.Count - 1]);
            Console.WriteLine("and the sum of which is {0}", NotAnAbundantSum.Sum());

            Console.Read();

        }

        public static bool IsAbundant(int n)
        {
            if (n < 12)     //12 is the smallest
            {
                return false;
            }
            int sum = MathFunctions.SumOfDivisors(n);
            if (sum > n)
            {
                return true;
            }
            return false;
        }

        public static bool IsAnAbundantSum(int n, List<int> abundantNums)
        {
            foreach (int num in abundantNums)
            {
                if (num > (n / 2) + 1)        //only check for AN < n/2
                {
                    return false;
                }
                if (abundantNums.Contains(n - num))     //if n - AN is an AN, n is the sum of 2 ANs
                {
                    return true;
                }
            }
            return false;
        }
    }
}
