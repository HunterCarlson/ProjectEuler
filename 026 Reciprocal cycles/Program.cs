using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_Reciprocal_cycles
{
    class Program
    {
        static void Main(string[] args)
        {
            //A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

            //    1/2	= 	0.5
            //    1/3	= 	0.(3)
            //    1/4	= 	0.25
            //    1/5	= 	0.2
            //    1/6	= 	0.1(6)
            //    1/7	= 	0.(142857)
            //    1/8	= 	0.125
            //    1/9	= 	0.(1)
            //    1/10	= 	0.1

            //Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

            //Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

            const int maxDigits = 20;
            int remainder;
            int divisor;

            for (int i = 2; i < 10; i++)
            {
                
                remainder = 1;
                divisor = i;
                Console.Write("1/{0} = 0.", divisor);
                for (int j = 0; j < maxDigits; j++)
                {
                    
                    remainder = remainder * 10;
                    int digit = remainder / divisor;
                    remainder = remainder % divisor;
                    Console.Write(digit);
                    if (remainder == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine();
                
            }

            //based on code at http://www.mathblog.dk/project-euler-26-find-the-value-of-d-1000-for-which-1d-contains-the-longest-recurring-cycle/
            int maxSequenceLength = 0;
            int makesMaxSequence = -1;
            for (int i = 2; i < 1000; i++)
            {
                int[] foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value = (value * 10) % i;
                    position++;
                }

                if (position - foundRemainders[value] > maxSequenceLength)
                {
                    maxSequenceLength = position - foundRemainders[value];
                    makesMaxSequence = i;
                }
            }
            Console.WriteLine("{0} makes the longest recurring cycle, which is {1} digits long", makesMaxSequence, maxSequenceLength);

            Console.Read();

        }

        public static int NDigitRecurringCycle(int n)
        {
            List<int> fraction = new List<int>();
            List<int> cycle = new List<int>();

            decimal one = 1.0M;
            decimal result = one / n;
            int length = result.ToString().Length;

            if (length < 10)        //not repeating
            {
                return -1;  //return -1 for not repeating
            }

            return cycle.Count;
           
        }
    }
}
