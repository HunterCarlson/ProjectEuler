using System;
using System.IO;

namespace _081_Path_sum___two_ways
{
    internal class Program
    {
        private static void Main(string[] args)
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
            int[][] matrix = CsvToMatrix(filename);

            var testMatrix = new int[5][];
            testMatrix[0] = new[] { 131, 673, 234, 103, 18 };
            testMatrix[1] = new[] { 201, 96, 342, 965, 150 };
            testMatrix[2] = new[] { 630, 803, 746, 422, 111 };
            testMatrix[3] = new[] { 537, 699, 497, 121, 956 };
            testMatrix[4] = new[] { 805, 732, 524, 37, 331 };

            //var testMatrix = new int[3][];
            //testMatrix[0] = new[] { 131, 673, 234 };
            //testMatrix[1] = new[] { 201, 96, 342 };
            //testMatrix[2] = new[] { 630, 803, 746 };

            Console.WriteLine(MinPathSum(testMatrix));

            Console.WriteLine(MinPathSum(matrix));

            Console.Read();
        }

        private static int[][] CsvToMatrix(string filename)
        {
            var matrix = new int[80][];
            var r = new StreamReader(filename);

            int rowNum = 0;
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                string[] values = line.Split(',');

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim('"');
                }
                var row = new int[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    row[i] = int.Parse(values[i]);
                }
                matrix[rowNum] = row;
                rowNum++;
            }
            r.Close();
            return matrix;
        }

        static int MinPathSum(int[][] m)
        {
            //int[][] is [y][x]
            int mSize = m.Length;
            //do the bottom row and left col
            //don't need to find Min() because they only have 1 neighbor
            for (int i = mSize - 1; i > 0; i--)
            {
                m[mSize - 1][i-1] += m[mSize - 1][i];
                m[i-1][mSize - 1] += m[i][mSize - 1];
            } 
            //collapse the rest by adding the smallest neighbor
            for (int i = mSize-2; i >= 0; i--)  //  row to do
            {
                for (int j = mSize - 2; j >= 0; j--)    //  element in row
                {
                    m[i][j] += Math.Min(m[i][j + 1], m[i + 1][j]);
                }
            }        
            return m[0][0];
        }

        static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    Console.Write("{0:D4}  ", matrix[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}