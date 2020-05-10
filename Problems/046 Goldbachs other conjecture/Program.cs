using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _046_Goldbachs_other_conjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

            // 9 =  7 + 2 × 1^2
            //15 =  7 + 2 × 2^2
            //21 =  3 + 2 × 3^2
            //25 =  7 + 2 × 3^2
            //27 = 19 + 2 × 2^2
            //33 = 31 + 2 × 1^2

            //It turns out that the conjecture was false.

            //What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?

            const int limit = 10000;
            int[] primes = MathFunctions.ESieve(limit);
            Console.WriteLine("prime list initialized");
            bool test = PrimeSquareDecomp(21, primes);

            for (int i = 3; i < limit; i+=2)
            {
                if (!(primes.Contains(i)))  //if i isn't prime it has to be an odd composite number
                {
                    if (!(PrimeSquareDecomp(i, primes)))
                    {
                        Console.WriteLine("{0} is the smallest odd composite that cannot be written as the sum of a prime and twice a square", i);
                        break;
                    }
                }
            }



            Console.Read();
        }

        static bool PrimeSquareDecomp(int n, int[] primes)
        {
            if (n % 2 == 0)
            {
                throw new InvalidOperationException("n is Even, n must be an odd composite number");
            }
            if (primes.Contains(n))
            {
                throw new InvalidOperationException("n is Prime, n must be an odd composite number");
            }

            for (int primeIndex = 0; primes[primeIndex] < n; primeIndex++)
            {
                int prime = primes[primeIndex]; 
                int squareBase = 1;
                int primeSquareSum = prime + 2 * squareBase * squareBase;
                while (primeSquareSum <= n)
                {
                    if (primeSquareSum == n)
                    {
                        //Console.WriteLine("{0} = {1} + 2 * {2}^2", n, prime, squareBase);
                        return true;
                    }
                    squareBase++;
                    primeSquareSum = prime + 2 * squareBase * squareBase;
                }  
            }
            //Console.WriteLine("can't decomp {0}", n);
            return false;
        }
    }
}
