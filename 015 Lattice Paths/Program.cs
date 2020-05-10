using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _015_Lattice_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, 
            //there are exactly 6 routes to the bottom right corner.
            // see pic at http://projecteuler.net/problem=15
            //How many such routes are there through a 20×20 grid?

            //brainstorm section
            //1x1 grid -> 2 routes
            //2x2 grid -> 6 routes
            //3x3 grid -> 20 routes 

            //after research, I found you can use binomial coefficients to calculate this

            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine("A {0} x {0} grid has {1} routes", i, LaticePaths(i));
            }

            Console.WriteLine(LaticePaths(20));
            Console.Read();

        }

        public static long LaticePaths(int n)
        {
            //the number of paths length (a + b) from (0, 0) to point (a, b)
            //is given by the  binomial coefficient 
            //
            //     (  a + b  )
            //    (  -------  )
            //     (    a    )

            return MathFunctions.BinomialCoefficient(n*2, n);

        }
    }
}
