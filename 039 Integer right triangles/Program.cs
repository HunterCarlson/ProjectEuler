using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _039_Integer_right_triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            //If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

            //{20,48,52}, {24,45,51}, {30,40,50}

            //For which value of p ≤ 1000, is the number of solutions maximised?

            Console.WriteLine(IsRightTriangle(20, 48, 52));

            const int limit = 1001;
            int[] solutionCount = new int[limit];
            int maxSolutions = 0;
            int givesMax = 0;

            for (int a = 0; a < limit; a++)
            {
                for (int b = a; b+a < limit; b++)
                {
                    for (int c = b; a+b+c < limit; c++)
                    {
                        if (IsRightTriangle(a, b, c))
                        {
                            solutionCount[a+b+c]++;
                        }
                    }
                }
            }
            maxSolutions = solutionCount.Max();
            List<int> searchable = solutionCount.ToList();
            givesMax = searchable.IndexOf(maxSolutions);

            Console.WriteLine("A triangle of perimeter {0} gives {1} solutions", givesMax, maxSolutions);





            Console.Read();
        }

        public static bool IsRightTriangle(int a, int b, int c)
        {
            List<int> triangle = new List<int>{ a, b, c };
            triangle.Sort();
            a = triangle[0];
            b = triangle[1];
            c = triangle[2];
            if (a*a + b*b == c*c)
            {
                return true;
            }
            return false;
        }
    }
}
