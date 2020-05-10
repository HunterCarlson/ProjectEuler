using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SumSquareDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            //The sum of the squares of the first ten natural numbers is,
            //1^2 + 2^2 + ... + 10^2 = 385
            //
            //The square of the sum of the first ten natural numbers is,
            //(1 + 2 + ... + 10)^2 = 55^2 = 3025
            //
            //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
            //
            //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

            int difference;

            difference = SquareOfSum(100) - SumOfSquares(100);

            Console.WriteLine(difference);
            Console.Read();


        }

        public static int SumOfSquares(int n)
        {
            return ( n * (n+1) * (2*n + 1) ) / 6;
        }

        public static int SquareOfSum(int n)
        {
            return n*n * (n+1)*(n+1) * 1/4;
        }
    }
}
