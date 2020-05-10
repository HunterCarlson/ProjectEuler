using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031_Coin_sums
{
    class Program
    {
        static void Main(string[] args)
        {
            //In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

            //    1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).

            //It is possible to make £2 in the following way:

            //    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p

            //How many different ways can £2 be made using any number of coins?


            int[] coinsUK = {1, 2, 5, 10, 20, 50, 100, 200};
            int[] coinsUSA = { 1, 5, 10, 25, 50, 100 };
            int targetAmount = 200;

            Console.WriteLine(WaysToMakeChange(targetAmount, coinsUK));

            Console.WriteLine(WaysToMakeChange(100, coinsUSA));


            Console.Read();
        }

        public static int WaysToMakeChange(int target, int[] coins)
        {
            int[] ways = new int[target + 1];
            ways[0] = 1;

            foreach (int coin in coins)
            {
                for (int i = coin; i <= target; i++)
                {
                    ways[i] += ways[i - coin];
                }
            }
            return ways[target];
        }

    }
}
