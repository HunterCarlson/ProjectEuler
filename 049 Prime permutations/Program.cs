using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _049_Prime_permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            //The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, 
            //is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.

            //There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, 
            //but there is one other 4-digit increasing sequence.

            //What 12-digit number do you form by concatenating the three terms in this sequence?

            const int limit = 10000;
            int[] primes = MathFunctions.ESieve(limit);

            Console.WriteLine(IsPrimePermutation(1487, primes));

            Console.WriteLine(MathFunctions.IsPermutationOf(55, 5));

            foreach (int n in primes)
            {
                if (IsPrimePermutation(n, primes))
                {
                    
                }
            }


            Console.Read();
        }

        

        static bool IsPrimePermutation(int n, int[] primes)
        {
            if (primes.Last() < n )
            {
                throw new InvalidOperationException("the list of primes must contain primes up to n");
            }
            for (int i = 2; i < 4500; i += 2)    //next number has to be prime, so increment by 2 to stay odd
            {
                int n2 = n + i;
                if (!MathFunctions.IsPermutationOf(n2, n) && !MathFunctions.IsPrime(n2))
                {
                    continue;
                }
                int n3 = n2 + i;
                if (!MathFunctions.IsPermutationOf(n3, n) && !MathFunctions.IsPrime(n3))
                {
                    continue;
                }
                if (MathFunctions.IsPermutationOf(n2, n) && MathFunctions.IsPrime(n2)
                    && MathFunctions.IsPermutationOf(n3, n) && MathFunctions.IsPrime(n3))
                {
                    Console.WriteLine("{0} {1} {2}", n, n2, n3);
                    return true;
                }
            }
            return false;
        }
    }
}
