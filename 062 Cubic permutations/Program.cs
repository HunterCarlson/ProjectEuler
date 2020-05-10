using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _062_Cubic_permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            //The cube, 41063625 (345^3), can be permuted to produce two other cubes: 56623104 (384^3) and 66430125 (405^3). 
            //In fact, 41063625 is the smallest cube which has exactly three permutations of its digits which are also cube.

            //Find the smallest cube for which exactly five permutations of its digits are cube.

            /*Notes:
             * smallest cube with 8 digits:
             * 216^3 = 10077696
             * 
             * int can only 9 digits
             * 
             * long can hold 18 digits
             * 
             * ANSWER:
             * The smallest cube with 5 permutations is 127035954683
             * Made from 5027^3
             */

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 8; i < 19; i++)
            {
                var answer = SmallestNDigitNumWithPCubicPerms(i, 5);
                if (answer != 0)
                {
                    break;
                }
            }

            Console.WriteLine("Done");
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.Read();
        }

        private static List<long> CubesInRange(long min, long max)
        {
            long baseMin = (long)Math.Pow(min, 1 / 3.0);
            long baseMax = (long)Math.Pow(max, 1 / 3.0);

            Console.WriteLine("min: {0}, max: {1}", baseMin, baseMax);

            List<long> cubes = new List<long>();

            for (long i = baseMin; i < baseMax; i++)
            {
                cubes.Add(Cube(i));
            }
            return cubes;
        }

        private static long Cube(long n)
        {
            return n * n * n;
        }

        static int CubicPermutations(long n, List<long> cubes)
        {
            int cubicPerms = 0;
            foreach (long cube in cubes)
            {
                if (MathFunctions.IsPermutationOf(cube, n))
                {
                    cubicPerms++;
                }
            }
            return cubicPerms;
        }

        static long SmallestNDigitNumWithPCubicPerms(int numDigits, int numPerms)
        {
            long min = (long)Math.Pow(10, numDigits - 1);
            long max = (long)Math.Pow(10, numDigits);

            var cubes = CubesInRange(min, max);

            long result = 0;

            foreach (long cube in cubes)
            {
                int cubicPerms = CubicPermutations(cube, cubes);
                if (CubicPermutations(cube, cubes) == numPerms)
                {
                    Console.WriteLine("{0} has {1} cubic permutaions", cube, cubicPerms);
                    result = cube;
                    break;
                }
            }
            if (result == 0)
            {
                Console.WriteLine("No result for {0} digit numbers", numDigits);
            }
            return result;
        }
    }
}
