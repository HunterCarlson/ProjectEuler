using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _078_Coin_partitions___with_list
{
    class Program
    {
        static void Main(string[] args)
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

            Stopwatch timer = new Stopwatch();
            timer.Start();

            const int modTarget = 1000000;
            const int limit = 60000;
            int[] numbers = Enumerable.Range(1, limit - 1).ToArray();
            int[] ways = new int[limit + 1];
            ways[0] = 1;

            List<int> waysList = new List<int> { 1, 2 };
            int n = 1;

            while (true)
            {
                waysList.Add(waysList.Last());
                for (int i = n; i < waysList.Count; i++)
                {
                    waysList[i] += waysList[i - n];
                    waysList[i] = waysList[i] % modTarget;
                }

                if (n == 10)
                {
                    //var p100 = waysList[100];
                }

                if (waysList[n] < 0)
                {
                    var givesError = ways[n];
                    throw new OverflowException(String.Format("{0} isn't big enough to hold the result", ways[0].GetType()));
                }

                if (waysList[n] % modTarget == 0)
                {
                    Console.WriteLine("p({0}) = {1}", n, waysList[n]);
                    break;
                }
                n++;
            }

            timer.Stop();
            Console.WriteLine("Solution took {0} ms", timer.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
