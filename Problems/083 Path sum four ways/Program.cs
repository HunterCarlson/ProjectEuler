using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace _083_Path_sum_four_ways
{
    internal class Program
    {
        private static void Main()
        {
            //NOTE: This problem is a significantly more challenging version of Problem 81.

            //In the 5 by 5 matrix below, the minimal path sum from the top left to the bottom right, 
            //by moving left, right, up, and down, is indicated in bold red and is equal to 2297.

            //131	673	234	103	18
            //201	96	342	965	150
            //630	803	746	422	111
            //537	699	497	121	956
            //805	732	524	37	331

            //Find the minimal path sum, in matrix.txt (right click and 'Save Link/Target As...'), 
            //a 31K text file containing a 80 by 80 matrix, from the top left to the bottom right by moving left, right, up, and down.

            const string filename = "matrix.txt";
            int[,] matrix = CsvToMatrix(filename);

            var testMatrix = new[,]
            {
                {131, 673, 234, 103, 18},
                {201, 96, 342, 965, 150},
                {630, 803, 746, 422, 111},
                {537, 699, 497, 121, 956},
                {805, 732, 524, 37, 331}
            };
            int testMatrixSize = testMatrix.GetLength(0);
            Console.WriteLine(AStar(testMatrix, 0, 0, testMatrixSize - 1, testMatrixSize - 1, true));

            int matrixSize = matrix.GetLength(0);
            Console.WriteLine(AStar(matrix, 0, 0, matrixSize - 1, matrixSize - 1));


            Console.Read();
        }

        private static int[,] CsvToMatrix(string filename)
        {
            var matrix = new int[80, 80];
            var r = new StreamReader(filename);

            int y = 0;
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                if (line != null)
                {
                    string[] values = line.Split(',');

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim('"');
                    }
                    for (int x = 0; x < values.Length; x++)
                    {
                        matrix[y, x] = int.Parse(values[x]);
                    }
                }
                y++;
            }
            r.Close();
            return matrix;
        }

        /// <summary>
        ///     Finds the min path cost from the two specified coordinates of a grid of values using A*
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="goalX"></param>
        /// <param name="goalY"></param>
        /// <param name="printSearchProgress">optional param to print the search progress</param>
        /// <returns></returns>
        private static int AStar(int[,] matrix, int startX, int startY, int goalX, int goalY,
            bool printSearchProgress = false)
        {
            int minVal = MinValInMatrix(matrix);
            int matrixSize = matrix.GetLength(0);
            var g = new int[matrixSize, matrixSize]; //movement cost to here
            var h = new int[matrixSize, matrixSize]; //estimated movement cost to goal
            var searched = new NodeStatus[matrixSize, matrixSize];

            var pathParents = new Dictionary<Tuple<int, int>, Tuple<int, int>>(); //key = child       value = parent

            var openList = new SortedList<Tuple<int, int>, Tuple<int, int>>();

            for (int y = 0; y < matrixSize; y++)
            {
                for (int x = 0; x < matrixSize; x++)
                {
                    //h = estimated cost to goal
                    int distance = Math.Abs(goalX - x) + Math.Abs(goalY - y);
                    h[y, x] = minVal*distance;
                    //g = movement cost to here. Not calculated yet, but don't want to start at 0, so start at intMax
                    g[y, x] = int.MaxValue;
                }
            }

            //first node
            g[startY, startX] = matrix[startY, startX];
            //f=g+h
            openList.Add(new Tuple<int, int>(g[startY, startX] + h[startY, startX], 0),
                new Tuple<int, int>(startY, startX));


            //while the goal is not in the closed set
            while (searched[goalY, goalX] < NodeStatus.Closed)
            {
                //pull lowest cost node from open list - this is the current node
                Tuple<int, int> currentNode = openList.ElementAt(0).Value;
                openList.RemoveAt(0);
                int currentY = currentNode.Item1;
                int currentX = currentNode.Item2;
                searched[currentY, currentX] = NodeStatus.Closed;

                //for display - prints the path search in action
                if (printSearchProgress)
                {
                    Console.Clear();
                    PrintNodeStatuses(searched);
                    Thread.Sleep(100);
                }

                //check the 4 adjacent squares
                for (int k = 0; k < 4; k++)
                {
                    int newX = 0;
                    int newY = 0;

                    switch (k)
                    {
                        case 0: //down
                            newY = currentY + 1;
                            newX = currentX;
                            break;
                        case 1: //right
                            newY = currentY;
                            newX = currentX + 1;
                            break;
                        case 2: //up
                            newY = currentY - 1;
                            newX = currentX;
                            break;
                        case 3: //left
                            newY = currentY;
                            newX = currentX - 1;
                            break;
                    }

                    //if the adjacent square being checked has valid coords and is not closed
                    if (newY >= 0 && newY < matrixSize &&
                        newX >= 0 && newX < matrixSize &&
                        searched[newY, newX] < NodeStatus.Closed)
                    {
                        //if movement cost has not been calculated or 
                        //if movement cost of the last path to here is greater than the current path to here
                        if (g[newY, newX] > g[currentY, currentX] + matrix[newY, newX])
                        {
                            g[newY, newX] = g[currentY, currentX] + matrix[newY, newX];

                            //make the parent of the adjacent node the current node
                            pathParents.Add(new Tuple<int, int>(newY, newX), currentNode);

                            //if the node being looked at is open
                            if (searched[newY, newX] == NodeStatus.Open)
                            {
                                //find the node in the open list
                                int index = openList.IndexOfValue(new Tuple<int, int>(newY, newX));
                                //and remove it from the open list
                                openList.RemoveAt(index);
                            }

                            //make sure the secondary key l is unique 
                            //f might not be unique per node, so we need a secondary key to ensure uniqueness of keys
                            int l = 0;
                            int f = g[newY, newX] + h[newY, newX];
                            while (openList.ContainsKey(new Tuple<int, int>(f, l)))
                            {
                                l++;
                            }
                            //add the node being looked at to the open list
                            openList.Add(new Tuple<int, int>(f, l), new Tuple<int, int>(newY, newX));
                            //record the node as being searched and open
                            searched[newY, newX] = NodeStatus.Open;
                        }
                    }
                }
            }

            //retrace the pathParents to find the path
            var pathNodes = new List<Tuple<int, int>>();
            //start at the end
            var currentPathNode = new Tuple<int, int>(matrixSize - 1, matrixSize - 1);
            //work back to the start
            while (!Equals(currentPathNode, new Tuple<int, int>(0, 0)))
            {
                pathNodes.Add(currentPathNode);
                currentPathNode = pathParents[currentPathNode];
            }
            pathNodes.Add(new Tuple<int, int>(0, 0));

            //mark the path
            foreach (var pathNode in pathNodes)
            {
                searched[pathNode.Item1, pathNode.Item2] = NodeStatus.Path;
            }

            //print the path graphically
            PrintPath(searched);
            //Thread.Sleep(5000);

            ////print the path numerically
            //foreach (Tuple<int, int> pathNode in pathNodes)
            //{
            //    Console.WriteLine("{0}, {1} = {2}", pathNode.Item1, pathNode.Item2, matrix[pathNode.Item1, pathNode.Item2]);
            //}
            //Console.WriteLine();

            //return path cost to bottom right node
            return g[goalY, goalX];
        }

        private static void PrintNodeStatuses(NodeStatus[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (matrix[i, j])
                    {
                        case NodeStatus.Unexplored:
                            Console.Write(".");
                            break;
                        case NodeStatus.Open:
                            Console.Write("O");
                            break;
                        case NodeStatus.Closed:
                            Console.Write("-");
                            break;
                    }
                    //Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void PrintPath(NodeStatus[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    NodeStatus nodeStatus = matrix[i, j];
                    Console.Write(nodeStatus == NodeStatus.Path ? "X " : ". ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int MinValInMatrix(int[,] matrix)
        {
            int min = int.MaxValue;
            foreach (int i in matrix)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }

// ReSharper disable once UnusedMember.Local
        private static int MaxValInMatrix(int[,] matrix)
        {
            int max = 0;
            foreach (int i in matrix)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

// ReSharper disable once UnusedMember.Local
        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0:D4}  ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private enum NodeStatus
        {
            Unexplored = 0,
            Open = 1,
            Closed = 2,
            Path = 10
        }
    }
}