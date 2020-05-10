using System;
using System.Linq;
using MyMathFunctions;

namespace _050_Consecutive_prime_sum
{
    class Program
    {
        static void Main()
        {
            //The prime 41, can be written as the sum of six consecutive primes:
            //41 = 2 + 3 + 5 + 7 + 11 + 13

            //This is the longest sum of consecutive primes that adds to a prime below one-hundred.

            //The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

            //Which prime, below one-million, can be written as the sum of the most consecutive primes?

            const int limit = 1000000;
            //sum of 536 terms from prime(0) = 958577       searching from only index0 first is much faster and gives a base limit to start from
            var mostTerms = 0;
            var longestSum = 0;
            var primes = MathFunctions.ESieve(limit);

            var primeSum = new int[primes.Length + 1];        //prime sum of P[i] to P[j] = primeSum[j] - primeSum[i]
            for (var i = 1; i <= primes.Length; i++)            //for n seq primes starting at P[i], sum = P[i+n] - P[i]
            {
                primeSum[i] = primeSum[i - 1] + primes[i - 1];
            }

            Console.WriteLine("{0} primes to search", primes.Length);

            //for (int TermsCount = 0; TermsCount < primes.Length; TermsCount++)
            //{
            //    for (int primeIndex = 0; primeIndex < primes.Length - TermsCount; primeIndex++)
            //    {
            //        int Sum = 0;
            //        for (int consecutivePrimes = 0; consecutivePrimes < TermsCount; consecutivePrimes++)
            //        {
            //            Sum += primes[primeIndex + consecutivePrimes];
            //            if (Sum > limit)
            //            {
            //                break;
            //            }
            //        }
            //        if (primes.Contains(Sum))
            //        {
            //            if (TermsCount > mostTerms)
            //            {
            //                mostTerms = TermsCount;
            //                LongestSum = Sum;
            //                Console.WriteLine("starting at prime({0}), the sum of {1} consecutive primes is {2}", primeIndex, TermsCount, Sum);
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine("searched to limit");


            for (var startIndex = 0; startIndex < primes.Length; startIndex++)
            {
                for (var sequentialPrimes = mostTerms; sequentialPrimes < primes.Length - startIndex; sequentialPrimes++)
                {
                    //prime sum of P[i] to P[j] = primeSum[j] - primeSum[i]
                    //for n seq primes starting at P[i], sum = P[i+n] - P[i]
                    var endIndex = startIndex + sequentialPrimes;

                    if (primeSum[endIndex] - primeSum[startIndex] > limit)
                    {
                        break;      //sequence sum can't be bigger than the limit
                    }

                    var sum = primeSum[endIndex] - primeSum[startIndex];
                    if (!primes.Contains(sum)) continue;
                    if (sequentialPrimes <= mostTerms) continue;
                    mostTerms = sequentialPrimes;
                    longestSum = sum;
                    Console.WriteLine("starting at prime({0}), the sum of {1} consecutive primes is {2}",
                        startIndex,
                        sequentialPrimes, longestSum);
                }
            }

            Console.WriteLine("{0} is the prime, below one-million, that can be written as the sum of the most consecutive primes", longestSum);

            Console.Read();
        }
    }
}
