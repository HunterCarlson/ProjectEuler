using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _076_Counting_summations
{
    class Program
    {
        static void Main(string[] args)
        {
            //It is possible to write five as a sum in exactly six different ways:

            //4 + 1
            //3 + 2
            //3 + 1 + 1
            //2 + 2 + 1
            //2 + 1 + 1 + 1
            //1 + 1 + 1 + 1 + 1

            //How many different ways can one hundred be written as a sum of at least two positive integers?

            Console.WriteLine(WaysToWriteAsSum(100));

            Console.Read();
        }

        public static int WaysToWriteAsSum(int target)
        {
            int[] numbers = Enumerable.Range(1, target - 1).ToArray();
            int[] ways = new int[target + 1];
            ways[0] = 1;

            foreach (int num in numbers)
            {
                for (int i = num; i <= target; i++)
                {
                    ways[i] += ways[i - num];
                }
            }
            return ways[target];
        }
    }
}
