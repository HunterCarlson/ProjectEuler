using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _028_Number_spiral_diagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

            //          21 22 23 24 25
            //          20  7  8  9 10
            //          19  6  1  2 11
            //          18  5  4  3 12
            //          17 16 15 14 13

            //It can be verified that the sum of the numbers on the diagonals is 101.

            //What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?

            int n = 5;
            int[,] testSpiral= NumberSpiral(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(testSpiral[i,j] + " ");
                }
                Console.WriteLine();
            }

            List<int> diags = MathFunctions.SpiralDiagonals(5);
            foreach (int num in diags)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine(diags.Sum());

            diags = MathFunctions.SpiralDiagonals(1001);
            Console.WriteLine(diags.Sum());
            Console.Read();
        }

        //do later, dont need for diagonal sum
        public static int[,] NumberSpiral(int n)
        {
            if (n % 2 == 0)
	        {
		        throw new InvalidOperationException("n must be odd to make a spiral");
	        }

            int[,] spiral = new int[n, n];
            int direction = 1;      //0=up, 1 = right, 2 = down, 3 = left
            //int lineLength = 1;     //line length starts at 2
            int row = n / 2;        //start in the middle
            int col = n / 2;

            for (int i = 1; i <= n*n; i++)
            {
                
            }
            spiral[row, col] = 1;   //center of spiral = 1
            col++;

            spiral[row, col] = 2;
            direction = (direction + 1) % 4; 
            row++;

            spiral[row, col] = 3;
            direction = (direction + 1) % 4; 
            col--;

            spiral[row, col] = 4;
            col--;
            spiral[row, col] = 5;
            row--;

            return spiral;
        }
    }
}
