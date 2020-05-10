using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _053_Combinatoric_selections
{
    class Program
    {
        static void Main(string[] args)
        {
            //There are exactly ten ways of selecting three from five, 12345:

            //123, 124, 125, 134, 135, 145, 234, 235, 245, and 345

            //In combinatorics, we use the notation, 5C3 = 10.

            //Mathfu - BinomialCoefficient

            //It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.

            //How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?

            /* Notes:
             * limit r values:
             * 100 C 3 = 100 C 97 = 161700
             * nC(x)=nC(n-x)
             * 
             * biggest will be nC(n/2) for maxN
             * =100 C 50
             * =1*10^29
             * 
             * 
             */  

            var watch = Stopwatch.StartNew();


            const int CValueMin = 1000000;
            const int nMax = 100;
            const int nMin = 23;
            const int rMax = 97;
            const int rMin = 3;

            int nCrOverOneMillionCount = 0;

            for (int n = nMin; n <= nMax; n++)
            {
                for (int r = rMin; r < n-1 && r <= rMax; r++)
                {
                    if (MathFunctions.BigBinomialCoefficient(n, r) > CValueMin)
                    {
                        nCrOverOneMillionCount++;
                    }
                }
            }
            Console.WriteLine(nCrOverOneMillionCount);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("{0} ms ellapsed", elapsedMs);

            Console.Read();
        }
    }
}
