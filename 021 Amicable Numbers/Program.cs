using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _021_Amicable_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
            //If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

            //For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; 
            //therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

            //Evaluate the sum of all the amicable numbers under 10000.

            //test area
            List<int> divisorsTest = MathFunctions.ListDivisors(220);
            divisorsTest.Sort();
            foreach (int divisor in divisorsTest)
            {
                Console.WriteLine(divisor);
            }

            Console.WriteLine("Sum of divisors of 220 = " + MathFunctions.SumOfDivisors(220));
            Console.WriteLine("Sum of divisors of 284 = " + MathFunctions.SumOfDivisors(284));
            Console.WriteLine("is 220 amicable? " + MathFunctions.IsAmicable(220));
            //end test area

            const int max = 10000;

            List<int> amicableNumbers = new List<int>();
            for (int i = 1; i < max; i++)
            {
                if (MathFunctions.IsAmicable(i))
                {
                    amicableNumbers.Add(i);
                }
            }

            Console.WriteLine("sum = " + amicableNumbers.Sum());

            Console.Read();
        }

    }
}
