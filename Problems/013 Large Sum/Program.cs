using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _013_Large_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
            //numbers are in BigNumberList.txt

            string filename = "BigNumberList.txt";

            long sum = 0;

            //need first 10 digits of sum, so only use first 11 digits of numbers
            int digitsToUse = 11;

            string line;
            StreamReader r = new StreamReader(filename);

            while ((line = r.ReadLine()) != null)
            {
                line = line.Substring(0, digitsToUse);
                sum += Convert.ToInt64(line);
            }
            r.Close();

            Console.WriteLine(sum);
            Console.Read();

        }
    }
}
