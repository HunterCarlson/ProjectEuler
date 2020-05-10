using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_Longest_Collatz_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //The following iterative sequence is defined for the set of positive integers:

            //n → n/2 (n is even)
            //n → 3n + 1 (n is odd)

            //Using the rule above and starting with 13, we generate the following sequence:
            //13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

            //It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

            //Which starting number, under one million, produces the longest chain?

            //NOTE: Once the chain starts the terms are allowed to go above one million.

            long longestChain;
            long makesLongestChain;
            const long maxNumber = 1000000;

            Stopwatch clock;

        //do with no caching
            clock = Stopwatch.StartNew();

            longestChain = 0;
            makesLongestChain = 0;
            for (long i = 2; i < maxNumber; i++)
            {
                long chainLength = CollatzLength(i);
                if (chainLength > longestChain)
                {
                    longestChain = chainLength;
                    makesLongestChain = i;
                }       
            }
            clock.Stop();

            Console.WriteLine("{0} has a collatz chain length of {1}", makesLongestChain, longestChain);
            Console.WriteLine("Without caching took {0} ms", clock.ElapsedMilliseconds);
        //end do without caching


        //do with caching
            clock = Stopwatch.StartNew();

            longestChain = 0;
            makesLongestChain = 0;
            var lengths = new Dictionary<long, long>();

            for (long i = 2; i < maxNumber; i++)
            {
                long chainLength = CollatzChainRecursive(i, lengths);
                if (chainLength > longestChain)
                {
                    longestChain = chainLength;
                    makesLongestChain = i;
                }              
            }
            clock.Stop();

            Console.WriteLine("{0} has a collatz chain length of {1}", makesLongestChain, longestChain);
            Console.WriteLine("With caching took {0} ms", clock.ElapsedMilliseconds);
        //end do with caching

            Console.Read();     //leave the console open       
        }

        public static long CollatzLength(long n)
        {
            long count = 1;
            long nPrevious = 1;      //for debugging
            while (n != 1)
            {
                
                if (n < 1)      //n should never be less than 1
                {
                    Console.WriteLine("previous value before error = {0}", nPrevious);
                    throw new InvalidOperationException("n should never be less than 1, n probably overflowed");
                }

                nPrevious = n;   //for debugging

                if (n % 2 == 0)     //if n is even
                {
                    n = n / 2;     
                }
                else                //if n is odd
                {
                    n = 3 * n + 1;
                }
                count++;
            }
            return count;
        }

        //slow sequential method I made
        public static List<int> CollatzChain(int n)
        {
            List<int> chain = new List<int>();
            chain.Add(n);       //add the initial number to the chain

            while (n != 1)
            {
                if (n % 2 == 0)     //if n is even
                {
                    n = n / 2;
                    chain.Add(n);
                }
                else                //if n is odd
                {
                    n = 3 * n + 1;
                    chain.Add(n);
                }
            }
            return chain;
        }

        //fast verison with recursion and caching
        public static long CollatzChainRecursive(long num, Dictionary<long, long> lengths)
        {
            if (num == 1)
            {
                return 1;
            }

            while (true)
            {
                if (lengths.ContainsKey(num))
                {
                    return lengths[num];
                }

                if (num%2 == 0)
	            {
                    lengths[num] = 1 + CollatzChainRecursive(num/2, lengths);
	            }
                else
	            {
                    lengths[num] = 1 + CollatzChainRecursive(3*num + 1, lengths);
	            }
            }
        }

    }
}
