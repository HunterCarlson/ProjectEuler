using System;
using System.Collections.Generic;
using System.IO;
using MyMathFunctions;

namespace _067_Maximum_path_sum_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //By starting at the top of the triangle below and moving to adjacent numbers on the row below, 
            //the maximum total from top to bottom is 23.

            //3
            //7 4
            //2 4 6
            //8 5 9 3

            //That is, 3 + 7 + 4 + 9 = 23.

            //Find the maximum total from top to bottom in triangle.txt, a 15K text file containing a triangle with one-hundred rows.

            const string filename = "triangle.txt";

            string line;
            var r = new StreamReader(filename);

            var triangleList = new List<int[]>();

            while ((line = r.ReadLine()) != null)
            {
                triangleList.Add(ParseLineToIntArray(line));
            }
            r.Close();

            int[][] numberTriangle = triangleList.ToArray();

            Console.WriteLine("The max path total is {0}", MaxPathValue(numberTriangle));


            Console.Read();
        }

        private static int[] ParseLineToIntArray(string line)
        {
            var ints = new List<int>();
            string[] splitString = line.Split(' ');
            foreach (string s in splitString)
            {
                ints.Add(int.Parse(s));
            }
            return ints.ToArray();
        }

        public static int MaxPathValue(int[][] triangle)
        {
            //collaspse the rows to get the max path value
            int[][] collapsedPath = MathFunctions.CopyJaggedArray(triangle);

            for (int row = triangle.Length - 2; row >= 0; row--)
            {
                for (int index = 0; index <= row; index++)
                {
                    collapsedPath[row][index] = triangle[row][index] +
                                                Math.Max(collapsedPath[row + 1][index],
                                                    collapsedPath[row + 1][index + 1]);
                }
            }

            return collapsedPath[0][0];
        }
    }
}