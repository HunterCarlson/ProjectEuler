using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _024_Lexicographic_Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            //A permutation is an ordered arrangement of objects. 
            //For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
            //If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. 
            //The lexicographic permutations of 0, 1 and 2 are:

            //012   021   102   120   201   210

            //What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?


            //notes:
            //10 elements have 10! permutations
            //10! = 3628800
            //fixing the first element 
            // 0 [1 2 3 4 5 6 7 8 9 ]
            //gives 9! permutations
            //9! = 362880, which is less than 1,000,000
            //
            //2 [0 1 3 4 5 6 7 8 9]
            //(2)*9! = 725760,        1M - 2*9! = 274240
            //2 7 [0 1 3 4 5 6 8 9]
            //(6)*8! = 241920         274240 - 6*8! = 32320
            //2 7 8 [0 1 3 4 5 6 9]
            //
            //so the sequence is:
            //1000000 = 2*9! - 6*8! - 6*7! - 2*6! - 5*5! - 1*4! - 2*3! - 1*2! - 1*1! - 1*0!
            //          2      6      6      2      5      1      2      1      1      1
            //
            //[0 1 2 3 4 5 6 7 8 9][index 2]
            //2 [0 1 3 4 5 6 7 8 9][index 6]
            //2 7 [0 1 3 4 5 6 8 9][index 6]
            //2 7 8 [0 1 3 4 5 6 9][index 2]
            //2 7 8 3 [0 1 4 5 6 9][index 5]
            //...
            //so start with array(length n), find x*(n - 1)! < 1M
            //return array[x], temp array = array - array[x]

            List<int> testList = new List<int> { 0, 1, 2 ,3};
            List<int> permutedTestList = MathFunctions.NthPermuatation(1, testList);
            foreach (int element in permutedTestList)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("-----");

            permutedTestList = MathFunctions.NthPermuatation(2, testList);
            foreach (int element in permutedTestList)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("-----");

            testList = new List<int> { 0, 1, 2, 3 ,4, 5, 6, 7, 8, 9};
            permutedTestList = MathFunctions.NthPermuatation(1000000, testList);
            foreach (int element in permutedTestList)
            {
                Console.WriteLine(element);
            }
            

            Console.Read();
        }
    }
}
