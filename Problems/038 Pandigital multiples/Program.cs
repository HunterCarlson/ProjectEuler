using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _038_Pandigital_multiples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Take the number 192 and multiply it by each of 1, 2, and 3:

            //    192 × 1 = 192
            //    192 × 2 = 384
            //    192 × 3 = 576

            //By concatenating each product we get the 1 to 9 pandigital, 192384576. 
            //We will call 192384576 the concatenated product of 192 and (1,2,3)

            //The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, 
            //giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).

            //What is the largest 1 to 9 pandigital 9-digit number that can be formed 
            //as the concatenated product of an integer with (1,2, ... , n) where n > 1?

            const int limit = 9999;    //biggest is 4 digits - 5 digits ends with 10 digit result which cant be pandigital
            List<int> PandigitalMultiples = new List<int>();

            int n = 9;
            int cProduct = ConcatProduct(n);
            bool isP = IsPandigital(cProduct);

            Console.WriteLine("Concat Product of {0} is {1} and Pandigital = {2}", n, cProduct, isP);
            n = 192;
            cProduct = ConcatProduct(n);
            isP = IsPandigital(cProduct);
            Console.WriteLine("Concat Product of {0} is {1} and Pandigital = {2}", n, cProduct, isP);
            n = 27;
            cProduct = ConcatProduct(n);
            isP = IsPandigital(cProduct);
            Console.WriteLine("Concat Product of {0} is {1} and Pandigital = {2}", n, cProduct, isP);


            int biggestN = 0;
            for (int i = 1; i < limit; i++)
            {
                cProduct = ConcatProduct(i);
                if (IsPandigital(cProduct))
                {
                    if (cProduct > biggestN)
                    {
                        biggestN = cProduct;
                    }
                }
            }
            Console.WriteLine("The largest Pandigital Concatenated Product is {0}", biggestN);

            Console.Read();
        }
        public static void AddDigitsToList(int n, List<int> list)
        {
            while (n > 0)
            {
                int digit = n % 10;
                n = n / 10;
                list.Add(digit);
            }
        }

        public static int ConcatProduct(int n)
        {
            int concatProduct = 0;
            string concatPString = "";
            int i = 1;
            while (concatPString.Length < 9)
            {
                int product = n * i;
                concatPString += product.ToString();
                int.TryParse(concatPString, out concatProduct);
                i++;
            }
            return concatProduct;
        }
        public static bool IsPandigital(int n)
        {
            List<int> resultDigits = new List<int>();

            AddDigitsToList(n, resultDigits);

            if (resultDigits.Count != 9)
            {
                return false;
            }
            if (resultDigits.Distinct().Count() != 9)
            {
                return false;
            }
            if (resultDigits.Contains(0))
            {
                return false;
            }
            return true;
        }
    }
}
