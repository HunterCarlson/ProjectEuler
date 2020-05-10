using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _085_Counting_rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            //By counting carefully it can be seen that a rectangular grid measuring 3 by 2 contains eighteen rectangles:

            /*
             *              +-------+-------+-------+
             *              |       |       |       |
             *              |       |       |       |
             *              +-------+-------+-------+
             *              |       |       |       |
             *              |       |       |       |
             *              +-------+-------+-------+
             */

            //Although there exists no rectangular grid that contains exactly two million rectangles, 
            //find the area of the grid with the nearest solution.

            const int goal = 2000000;

            int rectangles = RectanglesInGrid(2, 3);
            Console.WriteLine("{0} should = {1}", rectangles, 18);

            //min bound is square
            int min = int.MaxValue;
            for (int i = 1; i < int.MaxValue; i++)
            {
                int rs = RectanglesInGrid(i, i);
                if (rs > goal)
                {
                    min = i;
                    Console.WriteLine("R({0}, {1}) = {2}", i, i, rs);
                    break;
                }
            }       
      
            //max bound is flat/long
            int max = 0;
            for (int i = 1; i < int.MaxValue; i++)
            {
                int rs = RectanglesInGrid(1, i);
                if (rs > goal)
                {
                    max = i;
                    Console.WriteLine("R({0}, {1}) = {2}", 1, i, rs);
                    break;
                }
            }

            int x = 53;
            int y = 53;
            int cX = x;
            int cY = y;
            int r = RectanglesInGrid(x, y);
            int cR = r;
            int cDiff = Math.Abs(cR - goal);

            while (x != 1 && y != 2000)
            {
                if (r > goal)
                {
                    x--;
                }
                else
                {
                    y++;
                }
                r = RectanglesInGrid(x, y);
                int diff = Math.Abs(r - goal);
                if (diff < cDiff)
                {
                    cX = x;
                    cY = y;
                    cR = r;
                    cDiff = diff;
                }
            }
            Console.WriteLine("R({0}, {1}) = {2}", cX, cY, cR);


            var dummy = 0;
            Console.Read();
        }

        static int RectanglesInGrid(int x, int y)
        {
            int rPerRow = MathFunctions.TriangleNumber(x);
            int rPerCol = MathFunctions.TriangleNumber(y);
            int r = rPerCol*rPerRow;
            return r;
        }
    }
}
