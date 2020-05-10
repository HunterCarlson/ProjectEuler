﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _045_Triangular_pentagonal_and_hexagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
            //Triangle 	  	Tn=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
            //Pentagonal 	  	Pn=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
            //Hexagonal 	  	Hn=n(2n−1) 	  	1, 6, 15, 28, 45, ...

            //It can be verified that T285 = P165 = H143 = 40755.

            //Find the next triangle number that is also pentagonal and hexagonal.

            for (long i = 1; i < long.MaxValue; i++)
            {
                long triNum = MathFunctions.TriangleNumber(i);
                if (IsPentAndHex(triNum))
                {
                    Console.WriteLine("T{0}={1} is tri, pent, and hex", i, triNum);
                }
            }
            Console.WriteLine("Limit reached");

            Console.Read();
        }

        static bool IsPentAndHex(long n)
        {
            return MathFunctions.IsPentagonal(n) && MathFunctions.IsHexagonal(n);
        }

    }
}
