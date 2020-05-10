using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_SpecialPythagoreanTriplet
{
    class Program
    {
        static void Main(string[] args)
        {
            //A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
            //a^2 + b^2 = c^2
            //
            //For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
            //
            //There exists exactly one Pythagorean triplet for which a + b + c = 1000.
            //Find the product abc.
            int pa = -1;
            int pb = -1;
            int pc = -1;

            for (int a = 0; a < 1000; a++)
            {

                for (int b = a + 1; b < 1000; b++)
                {
                    int c = 1000 - a - b;

                    if (a*a + b*b == c*c)
                    {
                        pa = a;
                        pb = b;
                        pc = c;
                    }
                }
            }

            Console.WriteLine(pa + ", " + pb + ", " + pc);
            Console.Write(pa * pb * pc);
            Console.Read();

        }
    }
}
