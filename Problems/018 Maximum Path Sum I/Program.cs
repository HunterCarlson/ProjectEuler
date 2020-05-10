using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _018_Maximum_Path_Sum_I
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

            //3
            //7 4
            //2 4 6
            //8 5 9 3

            //That is, 3 + 7 + 4 + 9 = 23.

            //Find the maximum total from top to bottom of the triangle below:

            //                     75
            //                    95 64
            //                  17 47 82
            //                 18 35 87 10
            //                20 04 82 47 65
            //               19 01 23 75 03 34
            //              88 02 77 73 07 63 67
            //             99 65 04 28 06 16 70 92
            //           41 41 26 56 83 40 80 70 33
            //         41 48 72 33 47 32 37 16 94 29
            //        53 71 44 65 25 43 91 52 97 51 14
            //      70 11 33 28 77 73 17 78 39 68 17 57
            //    91 71 52 38 17 14 91 43 58 50 27 29 48
            //  63 66 04 68 89 53 67 30 73 16 69 87 40 31
            //04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

            //NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. 
            //However, Problem 67, is the same challenge with a triangle containing one-hundred rows; 
            //it cannot be solved by brute force, and requires a clever method! ;o)


            int[][] testTriangle = 
            {
            new int[] {3},
            new int[] {7, 4},
            new int[] {2, 4, 6},
            new int[] {8, 5, 9, 3}
            };

            int max = MaxPathValue(testTriangle);

            Console.WriteLine("The max path total is {0}", max);

            foreach (int n in MaxPath(testTriangle))
            {
                Console.WriteLine("{0}, ", n);
            }


            int[][] numberTriangle = 
            {
            new int[] {75},
            new int[] {95 ,64},
            new int[] {17 ,47 ,82},
            new int[] {18 ,35 ,87 ,10},
            new int[] {20 ,04 ,82 ,47 ,65},
            new int[] {19 ,01 ,23 ,75 ,03 ,34},
            new int[] {88 ,02 ,77 ,73 ,07 ,63 ,67},
            new int[] {99 ,65 ,04 ,28 ,06 ,16 ,70 ,92},
            new int[] {41 ,41 ,26 ,56 ,83 ,40 ,80 ,70 ,33},
            new int[] {41 ,48 ,72 ,33 ,47 ,32 ,37 ,16 ,94 ,29},
            new int[] {53 ,71 ,44 ,65 ,25 ,43 ,91 ,52 ,97 ,51 ,14},
            new int[] {70 ,11 ,33 ,28 ,77 ,73 ,17 ,78 ,39 ,68 ,17 ,57},
            new int[] {91 ,71 ,52 ,38 ,17 ,14 ,91 ,43 ,58 ,50 ,27 ,29 ,48},
            new int[] {63 ,66 ,04 ,68 ,89 ,53 ,67 ,30 ,73 ,16 ,69 ,87 ,40 ,31},
            new int[] {04 ,62 ,98 ,27 ,23 ,09 ,70 ,98 ,73 ,93 ,38 ,53 ,60 ,04 ,23}   
            };

           Console.WriteLine("The max path total is {0}", MaxPathValue(numberTriangle));
           foreach (int n in MaxPath(numberTriangle))
           {
               Console.WriteLine("{0}, ", n);
           }
            

            Console.Read();
        }

        public static int MaxPathValue(int[][] triangle)
        {
            //collaspse the rows to get the max path value
            int[][] collapsedPath = MathFunctions.CopyJaggedArray(triangle);

            for (int row = triangle.Length - 2; row >= 0; row--)
            {
                for (int index = 0; index <= row; index++)
                {
                    collapsedPath[row][index] = triangle[row][index] + Math.Max(collapsedPath[row + 1][index], collapsedPath[row + 1][index + 1]);
                }
            }

            return collapsedPath[0][0];
        }

        public static List<int> MaxPath(int[][] triangle)
        {
            //similar to above, but now keep track of path, not just total sum
            int[][] path = MathFunctions.CopyJaggedArray(triangle);
            int[][] collapsedPath = MathFunctions.CopyJaggedArray(triangle);

            List<int> maxPath = new List<int>();

            for (int row = triangle.Length - 2; row >= 0; row--)
            {
                for (int index = 0; index <= row; index++)
                {
                    collapsedPath[row][index] = triangle[row][index] + Math.Max(collapsedPath[row + 1][index], collapsedPath[row + 1][index + 1]);
                    if (triangle[row + 1][index] >= triangle[row + 1][index + 1])   //if left is bigger
                    {
                        path[row][index] = 0;       //record left
                    }
                    else        //if right is bigger
                    {
                        path[row][index] = 1;       //record right
                    } 
                }
            }

            int currentIndex = 0;
            maxPath.Add(triangle[0][0]); //add the first element as the start of the path
            for (int i = 0; i < triangle.Length - 1; i++)
            {
                if (path[i][currentIndex] == 0)     //go left, index stays the same
                {
                    maxPath.Add(triangle[i + 1][currentIndex]);
                }
                else        //go right, move index 1 right
                {
                    currentIndex++;
                    maxPath.Add(triangle[i + 1][currentIndex]);
                }
            }

            return maxPath;
        }
    }
}
