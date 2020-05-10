using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _086_Cuboid_route
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //A spider, S, sits in one corner of a cuboid room, measuring 6 by 5 by 3, and a fly, F, sits in the opposite corner. 
            //By travelling on the surfaces of the room the shortest "straight line" distance from S to F is 10 and the path is shown on the diagram.
            //However, there are up to three "shortest" path candidates for any given cuboid and the shortest route doesn't always have integer length.
            //By considering all cuboid rooms with integer dimensions, up to a maximum size of M by M by M, 
            //there are exactly 2060 cuboids for which the shortest route has integer length when M=100, 
            //and this is the least value of M for which the number of solutions first exceeds two thousand; 
            //the number of solutions is 1975 when M=99.
            //Find the least value of M such that the number of solutions first exceeds one million.

            /*Notes
             * if box is given by x,y,z
             * where z<=y<=x
             * min path is
             * sqrt( (x)^2 + (y + z)^2 )
             * by unfolding and making a straight line path
             */

            int goal = 2000;
            int M = LeastMForIntCuboidRouteSolsOverN(goal);
            Console.WriteLine(M);

            goal = 1000000;
            M = LeastMForIntCuboidRouteSolsOverN(goal);
            Console.WriteLine(M);  

            Console.Read();
        }

        static int LeastMForIntCuboidRouteSolsOverN(int goal)
        {
            int count = 0;
            int sideLen = 1;
            while (count < goal)
            {
                int x = sideLen;
                Parallel.For(1, x + 1, y =>
                {
                    for (int z = 1; z <= y; z++)
                    {
                        int yz = y + z;
                        int routeLen = x * x + yz * yz;
                        if (MathFunctions.IsSquare(routeLen))
                        {
                            Interlocked.Increment(ref count);
                        }
                    }
                }); //end Parallel.For
                Console.WriteLine("There are {0} int solutions for M = {1}", count, sideLen);
                sideLen++;
            }
            return sideLen-1;
        }
    }
}