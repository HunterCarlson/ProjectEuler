using System;
using System.Diagnostics;
using System.Linq;

namespace _078_Coin_partitions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Let p(n) represent the number of different ways in which n coins can be separated into piles. For example, five coins can separated into piles in exactly seven different ways, so p(5)=7.
            //OOOOO
            //OOOO   O
            //OOO   OO
            //OOO   O   O
            //OO   OO   O
            //OO   O   O   O
            //O   O   O   O   O

            //Find the least value of n for which p(n) is divisible by one million.

            /*Notes:
             * same as problem 76
             * the groups in the description above can be written as:
             * 5
             * 4 + 1
             * 3 + 2
             * 3 + 1 + 1
             * 2 + 2 + 1
             * 2 + 1 + 1 + 1
             * 1 + 1 + 1 + 1 + 1
             * 
             * which are the ways to write 5 as a sum + 1 (the +1 is the include the number itself)
             * 
             * long is way faster than BigInt so use mod
             * only have to keep track of the digits needed for %1,000,000
             * anything bigger wont effect the mod
             */

            var timer = new Stopwatch();
            timer.Start();

            const int modTarget = 1000000;
            const int limit = 100000;
            int[] numbers = Enumerable.Range(1, limit - 1).ToArray();
            var ways = new int[limit + 1];
            ways[0] = 1;

            foreach (int num in numbers)
            {
                for (int i = num; i <= limit; i++)
                {
                    ways[i] += ways[i - num];
                    ways[i] = ways[i]%modTarget;
                }

                if (ways[num] < 0)
                {
                    int givesError = ways[num];
                    throw new OverflowException(String.Format("{0} isn't big enough to hold the result",
                        ways[0].GetType()));
                }

                if (ways[num]%modTarget == 0)
                {
                    Console.WriteLine("p({0}) = {1}", num, ways[num]);
                    break;
                }
            }

            timer.Stop();
            Console.WriteLine("Solution took {0} ms", timer.ElapsedMilliseconds);
            Console.Read();
        }
    }
}