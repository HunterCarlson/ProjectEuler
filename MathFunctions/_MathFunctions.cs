using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace MyMathFunctions
{
    public static class MathFunctions
    {
        private const double Tolerance = 0.000001;

        private static void Main()
        {
        }


        //prime stuf
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;

            int counter = 5;
            while ((counter * counter) <= n)
            {
                if (n % counter == 0) return false;
                if (n % (counter + 2) == 0) return false;
                counter += 6;
            }
            return true;
        }

        public static bool BigIsPrime(BigInteger n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;

            BigInteger counter = 5;
            while ((counter * counter) <= n)
            {
                if (n % counter == 0) return false;
                if (n % (counter + 2) == 0) return false;
                counter += 6;
            }
            return true;
        }

        public static int NthPrime(int n)
        {
            int p = 1;
            int pthPrime = 2; //first prime is 2
            int i = pthPrime + 1;

            while (p < n)
            {
                if (IsPrime(i))
                {
                    pthPrime = i;
                    p++;
                }

                i += 2;
            }
            return pthPrime;
        }

        public static List<int> PrimesBelowN(int n) //using Sieve of Eratosthenes
        {
            var primes = new List<int>();

            var sieve = new bool[n]; //make an empy array wih n elements
            for (int i = 0; i < sieve.Length; i++) //initialise all elements to true
            {
                sieve[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(n); i++) //starting at 2
            {
                if (!sieve[i]) continue;
                for (int j = i*i; j < n; j += i)
                {
                    sieve[j] = false;
                }
            }
            // sieve is now only true for sieve[i] where i is prime

            //put primes in list
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        public static int[] ESieve(int upperLimit)
        {
            if (upperLimit == 2)
            {
                return new[] {2};
            }
            int sieveBound = (upperLimit - 1)/2;
            int upperSqrt = ((int) Math.Sqrt(upperLimit) - 1)/2;

            var primeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (!primeBits.Get(i)) continue;
                for (int j = i*2*(i + 1); j <= sieveBound; j += 2*i + 1)
                {
                    primeBits.Set(j, false);
                }
            }

            var numbers = new List<int>((int) (upperLimit/(Math.Log(upperLimit) - 1.08366))) {2};

            for (int i = 1; i <= sieveBound; i++)
            {
                if (primeBits.Get(i))
                {
                    numbers.Add(2*i + 1);
                }
            }

            return numbers.ToArray();
        } //optimized Sieve of Eratosthenes

        public static List<int> PrimeFactorization(int n)
        {
            var primeFactors = new List<int>();

            //add all the 2s that divide n to the list
            while (n%2 == 0)
            {
                primeFactors.Add(2);
                n = n/2;
            }
            // n must be odd at this point.  So we can skip one element (Note i = i +2)
            for (int i = 3; i <= Math.Sqrt(n); i = i + 2)
            {
                // While i divides n, add i to the list and divide n
                while (n%i == 0)
                {
                    primeFactors.Add(i);
                    n = n/i;
                }
            }

            // This condition is to handle the case whien n is a prime number
            // greater than 2
            if (n > 2)
            {
                primeFactors.Add(n);
            }

            return primeFactors;
        }


        //divisor stuff
        public static int NumberOfDivisors(long n)
        {
            int numDivisors = 2; //all numbers n have at least factors 1 and n
            var sqrt = (int) Math.Sqrt(n);

            for (int i = 1; i < sqrt; i++)
            {
                if (n%i == 0)
                {
                    numDivisors += 2; //add 2 because the divisors are i and n/i
                }
            }
            //Correction if the number is a perfect square
            if (sqrt*sqrt == n)
            {
                numDivisors--;
                    //added 2 earlier, but the square root would be counted twice, so subtract 1 from the total
            }
            return numDivisors;
        }

        public static int SumOfDivisors(int n)
        {
            return ListDivisors(n).Sum();
        }

        public static List<int> ListDivisors(int n)
        {
            var divisors = new List<int> {1};

            var sqrt = (int) Math.Sqrt(n);

            for (int i = 2; i <= sqrt; i++)
            {
                if (n%i == 0)
                {
                    //divisors are i and n/i
                    divisors.Add(i);
                    divisors.Add(n/i);
                }
            }
            return divisors.Distinct().ToList();
        }

        public static int GreatestCommonFactor(int a, int b)
        {
            int y;
            int x;

            if (a > b)
            {
                x = a;
                y = b;
            }
            else
            {
                x = b;
                y = a;
            }

            while (x%y != 0)
            {
                int temp = x;
                x = y;
                y = temp%x;
            }
            return y;
        }

        public static long GreatestCommonFactor(long a, long b)
        {
            long y;
            long x;

            if (a > b)
            {
                x = a;
                y = b;
            }
            else
            {
                x = b;
                y = a;
            }

            while (x % y != 0)
            {
                long temp = x;
                x = y;
                y = temp % x;
            }
            return y;
        }

        public static bool Coprime(int a, int b)
        {
            return GreatestCommonFactor(a, b) == 1;
        }
        public static bool Coprime(long a, long b)
        {
            return GreatestCommonFactor(a, b) == 1;
        }



        //combinatorics
        public static long BinomialCoefficient(int n, int k)
        {
            //formulaa is ( Factorial(n) ) / ( Factorial(n - k) * Factorial(k) );
            //but the multiplicitive formula is more efficient for individual coefficients
            if (k < 0 || k > n)
            {
                return 0;
            }
            if (k == 0 || k == n)
            {
                return 1;
            }
            k = Math.Min(k, n - k); //take advantage of symmetry
            long c = 1;
            for (long i = 0; i < k; i++)
            {
                c = c*(n - i)/(i + 1);
            }
            return c;
        }

        public static BigInteger BigBinomialCoefficient(int n, int k)
        {
            //formulaa is ( Factorial(n) ) / ( Factorial(n - k) * Factorial(k) );
            //but the multiplicitive formula is more efficient for individual coefficients
            if (k < 0 || k > n)
            {
                return 0;
            }
            if (k == 0 || k == n)
            {
                return 1;
            }
            k = Math.Min(k, n - k); //take advantage of symmetry
            BigInteger c = 1;
            for (long i = 0; i < k; i++)
            {
                c = c * (n - i) / (i + 1);
            }
            return c;
        }

        public static BigInteger Factorial(long n)
        {
            BigInteger product = 1;

            for (long i = 1; i <= n; i++)
            {
                product = product*i;
            }
            return product;
        }

        public static List<int> NthPermuatation(int n, List<int> elements)
        {
            elements.Sort();
            var maxPermutations = (int) Factorial(elements.Count);
                //returns BigInt, cast to normal - make sure not to use this with big numbers
            if (n > maxPermutations)
            {
                throw new InvalidOperationException("n must be less than possible number of permutations");
            }
            if (n <= 0)
            {
                throw new InvalidOperationException("n must be greater than or equal to 1");
            }

            //start actual algorithm
            var permutedList = new List<int>();
            var toBePermuted = new List<int>(elements);
            int remainder = n - 1;

            for (int i = 1; i < elements.Count; i++)
            {
                var factorial = (int) Factorial(elements.Count - i);
                int factorialMultiplier = remainder/factorial;
                remainder = remainder%factorial;

                int selectedElement = toBePermuted[factorialMultiplier];
                toBePermuted.Remove(selectedElement);
                permutedList.Add(selectedElement);

                if (remainder == 0)
                {
                    break;
                }
            }

            permutedList.AddRange(toBePermuted);

            return permutedList;
        }

        public static bool IsPermutationOf(int a, int b)
        {
            int[] arr = new int[10];

            int temp = a;
            while (temp > 0)
            {
                arr[temp % 10]++;
                temp /= 10;
            }

            temp = b;
            while (temp > 0)
            {
                arr[temp % 10]--;
                temp /= 10;
            }

            for (int i = 0; i < 10; i++)
            {
                if (arr[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsPermutationOf(long a, long b)
        {
            int[] arr = new int[10];

            long temp = a;
            while (temp > 0)
            {
                arr[temp % 10]++;
                temp /= 10;
            }

            temp = b;
            while (temp > 0)
            {
                arr[temp % 10]--;
                temp /= 10;
            }

            for (int i = 0; i < 10; i++)
            {
                if (arr[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<List<int>> PermutationsOf(List<int> elements)
        {
            var maxPermutations = (int) Factorial(elements.Count);
            var permutations = new List<List<int>>();

            for (int i = 1; i <= maxPermutations; i++)
            {
                permutations.Add(NthPermuatation(i, elements));
            }
            return permutations;
        }

        public static List<List<int>> UniquePermutationsOf(List<int> elements)
        {
            List<List<int>> permutations = new List<List<int>>(PermutationsOf(elements));
            List<List<int>> unique = UniqueListsIn(permutations);
            return unique;
        }

        public static List<List<int>> UniqueListsIn(List<List<int>> lists)
        {
            List<List<int>> unique = new List<List<int>>(lists);
            for (int i = 0; i < unique.Count; i++)
            {
                var perm = unique[i];
                for (int j = i + 1; j < unique.Count; j++)
                {
                    if (unique[j].SequenceEqual(perm))
                    {
                        unique.RemoveAt(j);
                    }
                }
            }
            return unique;
        }


        //array stuff
        public static int[] IntToDigitArray(long n)
        {
            int numDigits = n.ToString(CultureInfo.InvariantCulture).Length;

            var digitArray = new int[numDigits];
            long temp = n;
            for (int i = 0; i < numDigits; i++)
            {
                digitArray[numDigits - 1 - i] = (int) (temp%10);
                temp = temp/10;
            }
            return digitArray;
        }

        public static long DigitArrayToInt(int[] array)
        {
            long number = 0;
            long place = 1;
            int[] temp = array.Reverse().ToArray();
            foreach (int digit in temp)
            {
                number += digit*place;
                place *= 10;
            }
            return number;
        }
        public static BigInteger DigitArrayToBigInt(int[] array)
        {
            BigInteger number = 0;
            BigInteger place = 1;
            int[] temp = array.Reverse().ToArray();
            foreach (int digit in temp)
            {
                number += digit * place;
                place *= 10;
            }
            return number;
        }

        public static void AddDigitsToList(int n, List<int> list)
        {
            while (n > 0)
            {
                int digit = n%10;
                n = n/10;
                list.Add(digit);
            }
        }

        public static int[][] CopyJaggedArray(int[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }


        //number properties
        public static bool IsPandigital(int n)
        {
            int digits = 0;
            int count = 0;

            for (; n > 0; n /= 10, ++count)
            {
                if ((digits) == (digits |= 1 << (n - ((n/10)*10) - 1)))
                    return false;
            }

            return digits == (1 << count) - 1;
        }

        public static bool IsAmicable(int n)
        {
            //Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
            //If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.     
            int temp = SumOfDivisors(n);
            if (SumOfDivisors(temp) == n && temp != n) //If d(a) = b and d(b) = a, where a ≠ b
            {
                return true;
            }
            return false;
        }

        public static bool IsCube(int n)
        {
            double cubeTest = Math.Pow(n, 1/3.0);
            return Math.Abs(cubeTest - ((int)cubeTest)) < Tolerance;
        }



        //Euler's Totient / Phi
        public static int Totient(int n)
        {
            double totient = n;
            var primes = PrimeFactorization(n).Distinct();
            foreach (int prime in primes)
            {
                totient *= 1 - (1.0 / prime);
            }
            return (int)totient;
        }

        public static double PhiRatio(int n)
        {
            double phi = Phi(n);
            return n / phi;
        }

        public static long Phi(int n)
        {
            return PhiSieve(n)[n];
        }

        public static int[] PhiSieve(int limit)
        {
            int[] phi = Enumerable.Range(0, limit + 1).ToArray();
            for (int i = 2; i <= limit; i++)
            {
                if (phi[i] == i)
                {
                    for (int j = i; j <= limit; j += i)
                    {
                        phi[j] = phi[j] / i * (i - 1);
                    }
                }
            }
            return phi;
        }



        //geometric number stuff
        public static int TriangleNumber(int n)
        {
            //Triangle 	  	Tn=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n * (n + 1) / 2;
        }
        public static long TriangleNumber(long n)
        {
            //Triangle 	  	Tn=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n * (n + 1) / 2;
        }
        public static bool IsTriangular(int n)
        {
            double triTest = (Math.Sqrt(1 + 8 * n) - 1.0) / 2.0;
            return Math.Abs(triTest - ((int)triTest)) < Tolerance;
        }

        public static int SquareNumber(int n)
        {
            //Square 	  	Sn=n^2 	  	1, 4, 9, 16, 25, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n * n;
        }
        public static long SquareNumber(long n)
        {
            //Square 	  	Sn=n^2 	  	1, 4, 9, 16, 25, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n * n;
        }
        public static bool IsSquare(int n)
        {
            double squareTest = Math.Sqrt(n);
            return Math.Abs(squareTest - ((int)squareTest)) < Tolerance;
        }

        public static int PentagonalNumber(int n)
        {
            //Pentagonal 	  	Pn=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n*(3*n - 1)/2;
        }
        public static bool IsPentagonal(int n)
        {
            double penTest = (Math.Sqrt(1 + 24*n) + 1.0)/6.0;
            return Math.Abs(penTest - ((int) penTest)) < Tolerance;
        }
        public static bool IsPentagonal(long n)
        {
            double penTest = (Math.Sqrt(1 + 24*n) + 1.0)/6.0;
            return Math.Abs(penTest - ((long) penTest)) < Tolerance;
        }

        public static int HexagonalNumber(int n)
        {
            //Hexagonal 	  	Hn=n(2n−1) 	  	1, 6, 15, 28, 45, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n*(2*n - 1);
        }
        public static bool IsHexagonal(int n)
        {
            double hexTest = (Math.Sqrt(1 + 8*n) + 1.0)/4.0;
            return Math.Abs(hexTest - ((int) hexTest)) < Tolerance;
        }
        public static bool IsHexagonal(long n)
        {
            double hexTest = (Math.Sqrt(1 + 8*n) + 1.0)/4.0;
            return Math.Abs(hexTest - ((long) hexTest)) < Tolerance;
        }

        public static int HeptagonalNumber(int n)
        {
            //Heptagonal 	  	P7,n=n(5n−3)/2 	  	1, 7, 18, 34, 55, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n * (5 * n - 3) / 2;
        }
        public static bool IsHeptagonal(int n)
        {
            //Heptagonal 	  	P7,n=n(5n−3)/2 	  	1, 7, 18, 34, 55, ...
            double heptTest = (Math.Sqrt(9 + 40 * n) + 3.0) / 10.0;
            return Math.Abs(heptTest - ((int)heptTest)) < Tolerance;
        }
        public static bool IsHeptagonal(long n)
        {
            //Heptagonal 	  	P7,n=n(5n−3)/2 	  	1, 7, 18, 34, 55, ...
            double heptTest = (Math.Sqrt(9 + 40 * n) + 3.0) / 10.0;
            return Math.Abs(heptTest - ((long)heptTest)) < Tolerance;
        }

        public static int OctagonalNumber(int n)
        {
            //Octagonal 	  	P8,n=n(3n−2) 	  	1, 8, 21, 40, 65, ...
            if (n < 1)
            {
                throw new InvalidOperationException("n must be 1 or greater");
            }
            return n * (3 * n - 2);
        }
        public static bool IsOctagonal(int n)
        {
            //Octagonal 	  	P8,n=n(3n−2) 	  	1, 8, 21, 40, 65, ...
            double octTest = (Math.Sqrt(1 + 3 * n) + 1.0) / 3.0;
            return Math.Abs(octTest - ((int)octTest)) < Tolerance;
        }
        public static bool IsOctagonal(long n)
        {
            //Octagonal 	  	P8,n=n(3n−2) 	  	1, 8, 21, 40, 65, ...
            double octTest = (Math.Sqrt(1 + 3 * n) + 1.0) / 3.0;
            return Math.Abs(octTest - ((long)octTest)) < Tolerance;
        }


        //palindromes
        public static bool IsPalindrome(int n)
        {
            const int b = 10;
            int reversed = 0;
            int k = n;

            while (k > 0)
            {
                reversed = b * reversed + k % b;
                k /= b;
            }
            return n == reversed;
        }

        public static bool IsPalindrome(int n, int b)
        {
            int reversed = 0;
            int k = n;

            while (k > 0)
            {
                reversed = b * reversed + k % b;
                k /= b;
            }
            return n == reversed;
        }

        public static int ReverseNumber(int n)
        {
            const int b = 10;
            int reversed = 0;
            int k = n;

            while (k > 0)
            {
                reversed = b * reversed + k % b;
                k /= b;
            }
            return reversed;
        }

        public static BigInteger ReverseNumber(BigInteger number)
        {
            char[] k = number.ToString().ToCharArray();
            Array.Reverse(k);
            return BigInteger.Parse(new string(k));
        }

        public static bool IsPalindrome(BigInteger number)
        {
            return number == ReverseNumber(number);
        }



        public static BigInteger BigSqrt(BigInteger x)
        {
            int b = 15; // this is the next bit we try 
            BigInteger r = 0; // r will contain the result
            BigInteger r2 = 0; // here we maintain r squared
            while (b >= 0)
            {
                BigInteger sr2 = r2;
                BigInteger sr = r;
                // compute (r+(1<<b))**2, we have r**2 already.
                r2 += (uint) ((r << (1 + b)) + (1 << (b + b)));
                r += (uint) (1 << b);
                if (r2 > x)
                {
                    r = sr;
                    r2 = sr2;
                }
                b--;
            }
            return r;
        }

        public static string[] ReadCsvFile(string filename)
        {
            var r = new StreamReader(filename);
            string line = r.ReadToEnd();
            r.Close();

            string[] values = line.Split(',');

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim('"');
            }

            return values;
        }

        public static int AlphaValueSum(string s)
        {
            return s.Sum(letter => Convert.ToInt32(letter) - 64);
        }

        public static BigInteger DigitSum(BigInteger number)
        {
            BigInteger sum = 0;
            BigInteger temp = number;
            while (temp > 0)
            {
                sum += temp % 10;
                temp = temp / 10;
            }
            return sum;
        }
        public static int DigitFactorialSum(int number)
        {
            int[] f = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            int sum = 0;
            int temp = number;
            while (temp > 0)
            {
                sum += f[temp%10];
                temp = temp / 10;
            }
            return sum;
        }

        public static BigInteger PowBigInteger(BigInteger b, BigInteger p)
        {
            BigInteger result = b;
            for (int i = 1; i < p; i++)
            {
                result *= b;
            }
            return result;
        }
        public static int PowInt(int b, int p)
        {
            int result = b;
            for (int i = 1; i < p; i++)
            {
                result *= b;
            }
            if (result < 0)
            {
                throw new OverflowException();
            }
            return result;
        }


        public static List<int> SpiralDiagonals(int size)
        {
            List<int> diagonals = new List<int>();
            int skip = 1;
            int n = 1;
            int count = 0;
            while (n < size * size)
            {
                diagonals.Add(n);
                count++;
                n += skip + 1;
                if (count % 4 == 0)
                {
                    skip += 2;
                }
            }
            diagonals.Add(n);



            return diagonals;
        }

        public static BigInteger XToPowerN(int x, int n)
        {
            BigInteger result = x;
            for (int i = 1; i < n; i++)
            {
                result *= x;
            }
            return result;
        }

        /// <summary>
        /// Calculates the first N digits of Sqrt(s)
        /// </summary>
        /// <param name="s">square</param>
        /// <param name="l">digits</param>
        /// <returns></returns>
        public static int[] FirstNDigitsOfSqrt(int s, int l)
        {
            List<int> sqrtDigits = new List<int>();
            int digitPair;

            BigInteger remainder = 0;

            BigInteger p;
            int x;
            BigInteger y = 0;

            List<int> square = IntToDigitArray(s).ToList();

            if (square.Count % 2 == 1)
            {
                square.Insert(0, 0);
            }

            while (sqrtDigits.Count < l)
            {
                if (square.Any())
                {
                    digitPair = square[0] * 10 + square[1];
                    square.RemoveRange(0, 2);
                }
                else
                {
                    digitPair = 0;
                }

                BigInteger c = remainder * 100 + digitPair;

                if (!sqrtDigits.Any())
                {
                    p = 0;
                }
                else
                {
                    p = DigitArrayToBigInt(sqrtDigits.ToArray());
                }

                for (x = 0; x < 10; x++)
                {
                    BigInteger yNext = (x + 1) * (20 * p + (x + 1));   //next value of y
                    if (yNext > c)
                    {
                        y = x * (20 * p + x);
                        break;
                    }
                }
                sqrtDigits.Add(x);
                remainder = c - y;
            }
            return sqrtDigits.ToArray();
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write("{0}, ", item);
            }
        }

        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}