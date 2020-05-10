using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _074_Digit_factorial_chains
{
    class Program
    {
        static void Main(string[] args)
        {
            //The number 145 is well known for the property that the sum of the factorial of its digits is equal to 145:

            //1! + 4! + 5! = 1 + 24 + 120 = 145

            //Perhaps less well known is 169, in that it produces the longest chain of numbers that link back to 169; 
            //it turns out that there are only three such loops that exist:

            //169 → 363601 → 1454 → 169
            //871 → 45361 → 871
            //872 → 45362 → 872

            //It is not difficult to prove that EVERY starting number will eventually get stuck in a loop. For example,

            //69 → 363600 → 1454 → 169 → 363601 (→ 1454)
            //78 → 45360 → 871 → 45361 (→ 871)
            //540 → 145 (→ 145)

            //Starting with 69 produces a chain of five non-repeating terms, 
            //but the longest non-repeating chain with a starting number below one million is sixty terms.

            //How many chains, with a starting number below one million, contain exactly sixty non-repeating terms?

            Stopwatch timer = new Stopwatch();

            const int limit = 1000000;

            timer.Start();
            var lengths = new Dictionary<int, int>();

            int count = 0;
            for (int i = 1; i < limit; i++)
            {
                if (i == 1479)
                {
                    var dummy = 0;
                }
                if (DigitFactorialChainLengthCaching(i, lengths) == 60)
                {
                    count++;
                }
            }
            timer.Stop();
            Console.WriteLine("{0} chains contain 60 elements", count);
            Console.WriteLine("with caching took {0} ms", timer.ElapsedMilliseconds);

            timer.Restart();
            count = 0;
            for (int i = 1; i < limit; i++)
            {
                if (DigitFactorialChainLength(i) == 60)
                {
                    count++;
                }
            }
            timer.Stop();
            Console.WriteLine("{0} chains contain 60 elements", count);
            Console.WriteLine("without caching took {0} ms", timer.ElapsedMilliseconds);

            Console.Read();
        }

        static int DigitFactorialChainLength(int n)
        {
            int temp = n;
            List<int> chain = new List<int>();

            while (!chain.Contains(temp))
            {
                chain.Add(temp);
                temp = MathFunctions.DigitFactorialSum(temp);
            }
            return chain.Count;
        }

        static int DigitFactorialChainLengthCaching(int n, Dictionary<int, int> lengths )
        {
            List<int> chain = new List<int>(){n};
            int chainLength;

            while (!chain.Contains(MathFunctions.DigitFactorialSum(chain.Last()))
                && !lengths.ContainsKey(chain.Last()))
            {
                chain.Add(MathFunctions.DigitFactorialSum(chain.Last()));
            }

            if (lengths.ContainsKey(chain.Last()))
            {
                chainLength = chain.Count - 1 + lengths[chain.Last()];
            }
            else
            {
                chainLength = chain.Count;
            }

            lengths[n] = chainLength;
            return chainLength;
        }
    }
}
