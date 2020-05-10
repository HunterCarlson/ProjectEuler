using System;
using System.Collections.Generic;
using System.Linq;
using MyMathFunctions;

namespace _060_Prime_pair_sets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //The primes 3, 7, 109, and 673, are quite remarkable. 
            //By taking any two primes and concatenating them in any order the result will always be prime. 
            //For example, taking 7 and 109, both 7109 and 1097 are prime. 
            //The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.

            //Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.

            /*Notes:
             * 
             * 
             */

            int limit = 10000;
            int[] primes = MathFunctions.ESieve(limit);
            Console.WriteLine("{0} primes below {1}", primes.Count(), limit);

            List<int> primesInSetSize5 = ConcatPrimesWithLowestSum(primes.ToList(), 5);
            Console.WriteLine("Set: ");
            foreach (int i in primesInSetSize5)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Sum: {0}", primesInSetSize5.Sum());


            Console.WriteLine("Done");
            Console.Read();
        }

        private static List<int[]> UniquePairs(List<int> numberList)
        {
            var nums = new List<int>(numberList);
            var sets = new List<int[]>();
            while (nums.Count > 1)
            {
                int number = nums[0];
                for (int i = 1; i < nums.Count; i++)
                {
                    sets.Add(new[] {number, nums[i]});
                }
                nums.Remove(number);
            }
            var numPossibleSets = (int) MathFunctions.BinomialCoefficient(numberList.Count, 2);
            if (sets.Count != numPossibleSets)
            {
                throw new Exception(
                    "Something went wrong. The number of unique pairs should be (numElements Choose setSize)");
            }
            return sets;
        }

        private static List<int> ConcatPrimesWithLowestSum(List<int> numberList, int setSize)
        {
            var numPossibleSets = (int)MathFunctions.BinomialCoefficient(numberList.Count, setSize);
            Console.WriteLine("{0} sets to check", numPossibleSets);

            int lowestSum = int.MaxValue;
            var setWithLowestSum = new List<int>();

            //
            // TODO: check IfPrimeWhenConcat after each new prime so can exit nested loops faster
            //
            for (int p1 = 0; p1 < numberList.Count - setSize; p1++)
            {
                if (p1%100 == 0)
                {
                    Console.WriteLine("iteration {0} of {1}", p1, "derp");
                }
                
                for (int p2 = 0; p2 < p1; p2++)
                {
                    List<int> setToTest1 = new List<int>() { numberList[p1], numberList[p2]};
                    if (!IsPrimeWhenConcat(setToTest1))
                    {
                        continue;   
                    }

                    for (int p3 = 0; p3 < p2; p3++)
                    {
                        List<int> setToTest2 = new List<int>() { numberList[p1], numberList[p2], numberList[p3] };
                        if (!IsPrimeWhenConcat(setToTest2))
                        {
                            continue;
                        }

                        for (int p4 = 0; p4 < p3; p4++)
                        {
                            List<int> setToTest3 = new List<int>() { numberList[p1], numberList[p2], numberList[p3], numberList[p4] };
                            if (!IsPrimeWhenConcat(setToTest3))
                            {
                                continue;
                            }

                            for (int p5 = 0; p5 < p4; p5++)
                            {
                                List<int> setToTest = new List<int>(){numberList[p1], numberList[p2], numberList[p3], numberList[p4], numberList[p5]};
                                if (IsPrimeWhenConcat(setToTest))
                                {
                                    if (setToTest.Sum() < lowestSum)
                                    {
                                        lowestSum = setToTest.Sum();
                                        setWithLowestSum = setToTest;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return setWithLowestSum;
        }

        private static bool IsPrimeWhenConcat(List<int> numbers)
        {
            List<int[]> pairs = UniquePairs(numbers);
            foreach (var pair in pairs)
            {
                string num1 = pair[0].ToString();
                string num2 = pair[1].ToString();
                int concat1 = int.Parse(num1 + num2);
                int concat2 = int.Parse(num2 + num1);
                if (!MathFunctions.IsPrime(concat1) || !MathFunctions.IsPrime(concat2))
                {
                    return false;
                }
            }
            return true;
        }
    }
}