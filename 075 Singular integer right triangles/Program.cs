using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _75_Singular_integer_right_triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            //It turns out that 12 cm is the smallest length of wire that can be bent 
            //to form an integer sided right angle triangle in exactly one way, but there are many more examples.

            //12 cm: (3,4,5)
            //24 cm: (6,8,10)
            //30 cm: (5,12,13)
            //36 cm: (9,12,15)
            //40 cm: (8,15,17)
            //48 cm: (12,16,20)

            //In contrast, some lengths of wire, like 20 cm, cannot be bent to form an integer sided right angle triangle, 
            //and other lengths allow more than one solution to be found; 
            //for example, using 120 cm it is possible to form exactly three different integer sided right angle triangles.

            //120 cm: (30,40,50), (20,48,52), (24,45,51)

            //Given that L is the length of the wire, for how many values of L ≤ 1,500,000 can exactly one integer sided right angle triangle be formed?

            const int limit = 1500000;
            int sideMax = (int)Math.Sqrt(limit/2);

            int[] foundPerimeters = new int[limit + 1];
            int count = 0;

            for (long m = 2; m < sideMax ; m++)
            {
                for (long n = 1; n < m; n++)
                {     
                    if (((n+m)%2) == 1 && MathFunctions.Coprime(m, n))
                    {
                        long a = (m * m - n * n);
                        long b = (2 * m * n);
                        long c = (m * m + n * n);

                        long p = a + b + c;
                        while (p <= limit)
                        {
                            foundPerimeters[p]++;
                            if (foundPerimeters[p] == 1)
                            {
                                count ++;
                            }
                            if (foundPerimeters[p] == 2)
                            {
                                count--;
                            }
                            p += a + b + c;
                        }
                        
                    }
                }
            }
            Console.WriteLine(foundPerimeters[20]);

            Console.WriteLine(foundPerimeters.Count());
            Console.WriteLine(foundPerimeters.Count(x => x==1));
            Console.WriteLine(count);

            Console.Read();
        }
    }
}
