using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _047_Distinct_primes_factors
{
    class Program
    {
        static void Main(string[] args)
        {
            //The first two consecutive numbers to have two distinct prime factors are:

            //14 = 2 × 7
            //15 = 3 × 5

            //The first three consecutive numbers to have three distinct prime factors are:

            //644 = 2² × 7 × 23
            //645 = 3 × 5 × 43
            //646 = 2 × 17 × 19.

            //Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?

            const int distinctCount = 4;

            bool found = false;
            int[] numbers = new int[distinctCount];
            for (int i = 0; i < distinctCount; i++)
			{
			    numbers[i] = i+1;
			}
            while (!found)
            {
                for (int i = 0; i < distinctCount; i++)
			    {
		            if (!HasNDistinctPrimeFactors(numbers[distinctCount - 1 - i], distinctCount))
                    {
                        for (int j = 0; j < distinctCount; j++)     //if not found, increment to the next subset that could have the property
                        {
                            numbers[j] += distinctCount - i;
                        }
                        i = -1;  //reset the index counter
                    }
                    else if (AllHaveNDistinctPrimeFactors(numbers, distinctCount))
                    {
                        Console.WriteLine("The first {0} consecutive numbers to have {0} distinct prime factors are:", distinctCount);
                        foreach (int n in numbers)
                        {
                            Console.Write("{0} = ", n);
                            List<int> factors = MathFunctions.PrimeFactorization(n);
                            foreach (int factor in factors)
                            {
                                Console.Write("{0}, ", factor);
                            }
                            Console.WriteLine();
                        }
                        found = true;
                        break;
                    }
		    	}
            }


            Console.Read();
        }

        static int DistinctPrimeFactorsCount(int n)
        {
            return MathFunctions.PrimeFactorization(n).Distinct().Count();
        }
        static bool HasNDistinctPrimeFactors(int number, int distinctCount)
        {
            return DistinctPrimeFactorsCount(number) == distinctCount;
        }

        static bool AllHaveNDistinctPrimeFactors(int[] numbers, int distinctCount)
        {
            foreach (int n in numbers)
            {
                if (!HasNDistinctPrimeFactors(n, distinctCount))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
