using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _025_1000_digit_Fibonacci_number
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Fibonacci sequence is defined by the recurrence relation:

            //    Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

            //Hence the first 12 terms will be:

            //    F1 = 1
            //    F2 = 1
            //    F3 = 2
            //    F4 = 3
            //    F5 = 5
            //    F6 = 8
            //    F7 = 13
            //    F8 = 21
            //    F9 = 34
            //    F10 = 55
            //    F11 = 89
            //    F12 = 144

            //The 12th term, F12, is the first term to contain three digits.

            //What is the first term in the Fibonacci sequence to contain 1000 digits?




            //Fib(n) = round(phi^n / sqrt(5) )  for n > 0
            //and Log10(n) = number of digits
            //number with 1000 digits = 10^(1000 - 1)
            //so solve Fib(n) = round(phi^n / sqrt(5) ) = 10^999

            //n = round(4781.9) = 4782

        }
    }
}
