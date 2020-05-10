using System;
using System.Collections.Generic;
using System.Linq;
using MyMathFunctions;

namespace _051_Prime_digit_replacements_BruteForce
{
    internal class Program
    {
        private const int RepConstDigit = 0;
        private const int RepIterableDigit = -1;


        private static void Main()
        {
            //By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 
            //13, 23, 43, 53, 73, and 83, are all prime.

            //By replacing the 3rd and 4th digits of 56**3 with the same digit, 
            //this 5-digit number is the first example having seven primes among the ten generated numbers, 
            //yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, 
            //being the first member of this family, is the smallest prime with this property.

            //Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) 
            //with the same digit, is part of an eight prime value family.


            const int startingNumDigits = 6;
            const int desiredPrimeValueFamily = 8;

            bool found = false;
            int numDigits = startingNumDigits;
            List<int> primeFamily;

            Console.WriteLine("Desired prime value family: {0}", desiredPrimeValueFamily);
            Console.WriteLine();

            do
            {
                primeFamily = CheckNDigitNumbersForPrimeValueFamily(numDigits, desiredPrimeValueFamily);
                if (primeFamily.Count == desiredPrimeValueFamily)
                {
                    found = true;
                }
                if (!found)
                {
                    Console.WriteLine("{0} value prime family not found for {1} digit numbers", desiredPrimeValueFamily, numDigits);
                    Console.WriteLine();
                }
                numDigits++;
            } while (!found);

            Console.WriteLine();
            Console.WriteLine("The prime family with {0} members and the smallest starting prime is:",
                desiredPrimeValueFamily);
            foreach (int n in primeFamily)
            {
                Console.WriteLine(n);
            }


            Console.Read();
        }

        private static List<List<int>> GenerateBasesToPermute(int digits, int maxReplaceableDigits)
        {
            var basesToBePermuted = new List<List<int>>();
            for (int i = 0; i < maxReplaceableDigits; i++)
            {
                basesToBePermuted.Add(new List<int>());
                for (int j = 0; j < digits; j++)
                {
                    if (j < i + 1)
                    {
                        basesToBePermuted[i].Add(RepConstDigit); //indicates constant digit
                    }
                    else
                    {
                        basesToBePermuted[i].Add(RepIterableDigit); //indicates this is the digit to change
                    }
                }
            }
            return basesToBePermuted;
        }

        private static List<int> PrimeFamilyFromBasePerm(int[] basePerm, int[] primes)
        {
            List<int> generatedNumbers = GenerateNumbersFromBasePerm(basePerm);

            var generatedPrimes = new List<int>();

            foreach (int number in generatedNumbers)
            {
                if (primes.Contains(number))
                {
                    generatedPrimes.Add(number);
                }
            }

            return generatedPrimes;
        }

        private static List<int> GenerateNumbersFromBasePerm(int[] basePerm)
        {
            var generatedNumbers = new List<int>();

            for (int iterableDigit = 0; iterableDigit <= 9; iterableDigit++)
            {
                var digitPerm = new int[basePerm.Length];
                Array.Copy(basePerm, digitPerm, basePerm.Length);

                SetIterableDigitsTo(digitPerm, iterableDigit);

                var number = (int) MathFunctions.DigitArrayToInt(digitPerm);

                if (number.ToString().Length == digitPerm.Length)
                    //check they are the same length to get rid of leading zeroes
                {
                    generatedNumbers.Add(number);
                }
            }

            return generatedNumbers;
        }

        private static void SetIterableDigitsTo(int[] digitPerm, int iterableDigit)
        {
            for (int i = 0; i < digitPerm.Length; i++)
            {
                if (digitPerm[i] == RepIterableDigit) //if RepIterableDigit, that iterable digit needs to be permuted
                {
                    digitPerm[i] = iterableDigit;
                }
            }
        }

        private static void SetConstDigitsTo(int[] basePerm, List<int> baseDigits)
        {
            for (int i = basePerm.Length - 1; i >= 0; i--) //go backwards to start with the ones place
            {
                if (basePerm[i] == RepConstDigit) //if RepConstDigit, that base digit needs to be permuted
                {
                    if (!baseDigits.Any()) //if the digits to add are empty there was a leading zero
                    {
                        baseDigits.Add(0); //add the leading zero back in
                    }
                    basePerm[i] = baseDigits.Last();
                    baseDigits.RemoveAt(baseDigits.Count - 1);
                }
            }
        }

        private static List<List<int>> UniquePermutationsFor(int digits, int maxReplaceableDigits)
        {
            List<List<int>> basesToBePermuted = GenerateBasesToPermute(digits, maxReplaceableDigits);

            var almostUniquePermutations = new List<List<int>>();
            foreach (var baseToPermute in basesToBePermuted)
            {
                List<List<int>> temp = MathFunctions.UniquePermutationsOf(baseToPermute);
                foreach (var list in temp)
                {
                    almostUniquePermutations.Add(list);
                }
            }
            List<List<int>> uniquePermutations = MathFunctions.UniqueListsIn(almostUniquePermutations);

            return uniquePermutations;
        }

        private static List<int> CheckNDigitNumbersForPrimeValueFamily(int nDigits, int desiredPrimeValueFamily)
        {
            int maxReplaceableDigits = nDigits - 1;

            var primeFamilyWithSmallestStarter = new List<int> {int.MaxValue};
            int[] primes = MathFunctions.ESieve((int) Math.Pow(10, nDigits));

            List<List<int>> uniquePermutations = UniquePermutationsFor(nDigits, maxReplaceableDigits);

            Console.WriteLine("For {0} digit numbers,", nDigits);
            Console.WriteLine("there are {0} unique permutations to check", uniquePermutations.Count);

            ////print the base permuatations
            //foreach (List<int> perm in uniquePermutations)
            //{
            //    Console.WriteLine(string.Join(" ", perm));
            //}

            //start checking permutations
            int permCount = 0;
            foreach (var permutation in uniquePermutations)
            {
                int maxBaseDigitIters = 1;
                foreach (int n in permutation)
                {
                    if (n == RepConstDigit)
                    {
                        maxBaseDigitIters *= 10;
                    }
                }
                for (int baseDigitIter = 0; baseDigitIter <= maxBaseDigitIters; baseDigitIter++)
                    //permute each digit individually
                {
                    var basePerm = new int[permutation.Count];
                    permutation.CopyTo(basePerm);

                    var baseDigitsToInsertIntoPerm = new List<int>(MathFunctions.IntToDigitArray(baseDigitIter));
                    SetConstDigitsTo(basePerm, baseDigitsToInsertIntoPerm);

                    List<int> generatedPrimes = PrimeFamilyFromBasePerm(basePerm, primes);

                    if (generatedPrimes.Count == desiredPrimeValueFamily)
                        //if the generated prime family has the desired number of primes
                    {
                        if (!primeFamilyWithSmallestStarter.Any() //if the existing list is empty OR
                            || generatedPrimes[0] < primeFamilyWithSmallestStarter[0])
                            //if the new prime family starts with a smaller number
                        {
                            primeFamilyWithSmallestStarter = new List<int>(generatedPrimes);
                        }
                    }
                }
                Console.WriteLine("Permuation {0}/{1} complete", permCount, uniquePermutations.Count);
                permCount++;
            }
            return primeFamilyWithSmallestStarter;
        }
    }
}