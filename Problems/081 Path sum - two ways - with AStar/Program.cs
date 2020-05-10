using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _081_Path_sum___two_ways___with_AStar
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //In the 5 by 5 m below, the minimal path sum from the top left to the bottom right, 
            //by only moving to the right and down, is indicated in bold red and is equal to 2427.

            //131	673	234	103	18
            //201	96	342	965	150
            //630	803	746	422	111
            //537	699	497	121	956
            //805	732	524	37	331

            //Find the minimal path sum, in m.txt, a 31K text file containing a 80 by 80 m, 
            //from the top left to the bottom right by only moving right and down.

            const string filename = "matrix.txt";
            int[,] matrix = CsvToMatrix(filename);

            var testMatrix = new int[5,5]
            {
                { 131, 673, 234, 103, 18 },
                { 201, 96, 342, 965, 150 },
                { 630, 803, 746, 422, 111 },
                { 537, 699, 497, 121, 956 },
                { 805, 732, 524, 37, 331 }
            };
            int testMatrixSize = testMatrix.GetLength(0);

            Console.WriteLine(AStarCornerToCorner(testMatrix));

            Console.Read();
        }

        private static int[,] CsvToMatrix(string filename)
        {
            var matrix = new int[80,80];
            var r = new StreamReader(filename);

            int y = 0;
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                string[] values = line.Split(',');

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim('"');
                }
                var row = new int[values.Length];
                for (int x = 0; x < values.Length; x++)
                {
                    matrix[x,y] = int.Parse(values[x]);
                }
                y++;
            }
            r.Close();
            return matrix;
        }

        /// <summary>
        /// Finds the min path cost from the top left corner to the bottom right corner of a grid of values using A*
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static int AStarCornerToCorner(int[,] matrix)
        {
            int minVal = MinValInMatrix(matrix);
            int matrixSize = matrix.GetLength(0);
            int[,] g = new int[matrixSize, matrixSize];     //movement cost to here
            int[,] h = new int[matrixSize, matrixSize];     //estimated movement cost to goal
            NodeStatus[,] searched = new NodeStatus[matrixSize, matrixSize];

            var openList = new SortedList<Tuple<int, int>, Tuple<int, int>>();

            for (int y = 0; y < matrixSize; y++)
            {
                for (int x = 0; x < matrixSize; x++)
                {
                    //h = estimated cost to goal
                    int distance = 2*(matrixSize-1) - y - x;
                    h[y, x] = minVal*distance;
                    //g = movement cost to here. Not calculated yet, but don't want to start at 0, so start at intMax
                    g[y, x] = int.MaxValue;
                }
            }

            //first node
            g[0, 0] = matrix[0, 0];
            //f=g+h
            openList.Add(new Tuple<int, int>(g[0,0] + h[0,0], 0), new Tuple<int, int>(0, 0));

            while (searched[matrixSize -1, matrixSize - 1] < NodeStatus.closed)
            {
                //pull lowest cost node from open list - this is the current node
                Tuple<int, int> currentNode = openList.ElementAt(0).Value;
                openList.RemoveAt(0);
                int currentY = currentNode.Item1;
                int currentX = currentNode.Item2;
                searched[currentY, currentX] = NodeStatus.closed;

                //check the 2 adjacent squares
                for (int k = 0; k < 2; k++)
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
                        //case 2: //up
                        //    newY = currentY - 1;
                        //    newX = currentX;
                        //    break;
                        //case 3: //left
                        //    newY = currentY;
                        //    newX = currentX - 1;
                        //    break;
                    }

                    //if the adjacent square being checked has valid coords and is not closed
                    if (newY >= 0 && newY < matrixSize &&
                        newX >= 0 && newX < matrixSize &&
                        searched[newY, newX] < NodeStatus.closed)
                    {
                        //if movement cost has not been calculated or 
                        //if movement cost of the last path to here is greater than the current path to here
                        if (g[newY, newX] > g[currentY, currentX] + matrix[newY, newX])
                        {
                            g[newY, newX] = g[currentY, currentX] + matrix[newY, newX];

                            //if the node being looked at is open
                            if (searched[newY, newX] == NodeStatus.open)
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
                            searched[newY, newX] = NodeStatus.open;
                        }
                    }
                }
            }

            //return path cost to bottom right node
            return g[matrixSize - 1, matrixSize - 1];
        }

        static int MinValInMatrix(int[,] matrix)
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

        enum NodeStatus
        {
            unexplored = 0, open = 1, closed = 2
        }
    }
}
