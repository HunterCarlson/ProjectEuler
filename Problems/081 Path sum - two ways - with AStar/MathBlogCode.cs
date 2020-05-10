using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace euler
{
    class Problem83
    {

        public static void Main1(string[] args)
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\input.txt";
            new Problem83().Astar(filename);
        }

        int[,] grid;

        public void Astar(string filename)
        {

            Stopwatch clock = Stopwatch.StartNew();

            //init arrays
            int minval = readInput(filename);
            int gridSize = grid.GetLength(0);
            int[,] g = new int[gridSize, gridSize];
            int[,] h = new int[gridSize, gridSize];
            int[,] searched = new int[gridSize, gridSize];

            SortedList<Tuple<int, int>, Tuple<int, int>> openList = new SortedList<Tuple<int, int>, Tuple<int, int>>();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    h[i, j] = minval * (2 * (gridSize - 1) + 1 - i - j);
                    g[i, j] = int.MaxValue;
                }
            }

            //Add the start square
            g[0, 0] = grid[0, 0];
            openList.Add(new Tuple<int, int>(g[0, 0] + h[0, 0], 0), new Tuple<int, int>(0, 0));

            while (searched[gridSize - 1, gridSize - 1] < 2)
            {
                Tuple<int, int> current = openList.ElementAt(0).Value;
                openList.RemoveAt(0);
                int ci = current.Item1;
                int cj = current.Item2;
                searched[current.Item1, current.Item2] = 2;

                //Check the four adjacent squares
                for (int k = 0; k < 4; k++)
                {

                    int cinew = 0;
                    int cjnew = 0;

                    switch (k)
                    {
                        case 0: //Check the square above
                            cinew = ci - 1;
                            cjnew = cj;
                            break;
                        case 1: //Check the square below
                            cinew = ci + 1;
                            cjnew = cj;
                            break;
                        case 2: //Check the square right
                            cinew = ci;
                            cjnew = cj + 1;
                            break;
                        case 3: //Check the square left
                            cinew = ci;
                            cjnew = cj - 1;
                            break;
                    }

                    if (cinew >= 0 && cinew < gridSize &&
                        cjnew >= 0 && cjnew < gridSize &&
                        searched[cinew, cjnew] < 2)
                    {
                        if (g[cinew, cjnew] > g[ci, cj] + grid[cinew, cjnew])
                        {
                            g[cinew, cjnew] = g[ci, cj] + grid[cinew, cjnew];

                            if (searched[cinew, cjnew] == 1)
                            {
                                int index = openList.IndexOfValue(new Tuple<int, int>(cinew, cjnew));
                                openList.RemoveAt(index);
                            }
                            int l = 0;
                            while (openList.ContainsKey(new Tuple<int, int>(g[cinew, cjnew] + h[cinew, cjnew], l))) l++;
                            openList.Add(new Tuple<int, int>(g[cinew, cjnew] + h[cinew, cjnew], l), new Tuple<int, int>(cinew, cjnew));
                            searched[cinew, cjnew] = 1;
                        }
                    }
                }
            }
            clock.Stop();
            Console.WriteLine("In the {0}x{0} grid the min path is {1}", gridSize, g[gridSize - 1, gridSize - 1]);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
        }

        private void printGrid(int[,] grid)
        {
            int gridSize = grid.GetLength(0);

            for (int k = 0; k < gridSize; k++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write(grid[k, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }



        private int readInput(string filename)
        {
            int lines = 0;
            string line;
            string[] linePieces;
            int minval = int.MaxValue;

            StreamReader r = new StreamReader(filename);
            while (r.ReadLine() != null)
            {
                lines++;
            }

            grid = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(',');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    grid[j, i] = int.Parse(linePieces[i]);
                    minval = (minval > grid[j, i]) ? grid[j, i] : minval;
                }
                j++;
            }

            r.Close();
            return minval;

        }


    }
}
