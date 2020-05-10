using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_LargestPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            //The prime factors of 13195 are 5, 7, 13 and 29.
            //What is the largest prime factor of the number 600851475143 ?

            const long number = 600851475143;
            long result = number;
            int gpf;

            for (gpf = 2; gpf < result; gpf++)
            {
                if (result % gpf == 0)
                {
                    result = result / gpf;
                    gpf--;
                }
            }

            Console.WriteLine(gpf);
            Console.ReadLine();
        }
    }
}
