using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _062_Cubic_Permutations___better
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            SortedList<long, Cube> cubes = new SortedList<long, Cube>();

            long b = 1; //345
            while (true)
            {
                b++;
                long n = b*b*b;
                long key = LargestPerm(n);
                if (!cubes.ContainsKey(key))
                {
                    cubes.Add(key, new Cube{N = n, Perms = 1});
                }
                else
                {
                    cubes[key].Perms++;
                }

                if (cubes[key].Perms == 5)
                {
                    Console.WriteLine(cubes[key].N);
                    break;
                }
                
            }
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds + " ms");
            Console.Read();
        }

        static long LargestPerm(long n)
        {
            var digits = MathFunctions.IntToDigitArray(n).ToList();
            digits.Sort();
            digits.Reverse();
            var largestPerm = MathFunctions.DigitArrayToInt(digits.ToArray());
            return largestPerm;
        }

    }

    class Cube
    {
        public long N { get; set; }
        public int Perms { get; set; }
    }
}
