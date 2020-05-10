using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SmallestMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
            //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

            //number has to be divisible by 10, so must end in 0
            //by 20, so must end in a multipe of 20: 00, 20, 40, 60, 80
            //so increment by 20
            //if the number is divisible by a multiple of n, it is also divisible by n
            //so only need to check if divisible by 
            //19, 18, 17, 16, 15, 14, 13, 12, 11

            bool isMultiple = false;
            int scm = 0;
            int n = 20;
            while (!isMultiple)
            {
                for (int divisor = 11; divisor <= 19; divisor++)    //divide by [11, 19]
                {
                    if (!(n % divisor == 0))
                    {
                        break;
                    }
                    if (divisor == 19)      //divisible by all
                    {
                        isMultiple = true;
                        scm = n;
                    }
                }
                n += 20;
            }

            Console.WriteLine(scm);
            Console.Read();
        }
    }
}
