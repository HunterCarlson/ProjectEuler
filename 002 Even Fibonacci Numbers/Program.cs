using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_EvenFibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 2;
            int[] fib = {2, 1, 1, 0};
            do
            {
                fib[3] = fib[2];
                fib[2] = fib[1];
                fib[1] = fib[0];
                fib[0] = fib[1] + fib[2];

                if (fib[0] % 2 == 0)
                {
                    sum += fib[0];
                }
            } while (fib[0] < 4000000);

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
