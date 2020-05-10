using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _032_Pandigital_products
{
    class Program
    {
        static void Main(string[] args)
        {
            //We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

            //The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

            //Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
            //HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.

            Console.WriteLine(IsPandigitalProduct(39, 186));

            List<int> PandigitalProducts = new List<int>();
            const int limit = 10000;

            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    if (IsPandigitalProduct(i, j))
                    {
                        PandigitalProducts.Add(i * j);
                        Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
                    }
                }
            }

            PandigitalProducts = PandigitalProducts.Distinct().ToList();

            Console.WriteLine("There are {0} pandigital products", PandigitalProducts.Count);
            Console.WriteLine("Their sum is {0}", PandigitalProducts.Sum());

            //There are 7 pandigital products
            //Their sum is 45228

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

        public static bool IsPandigitalProduct(int m1, int m2)
        {
            int product = m1 * m2;

            List<int> resultDigits = new List<int>();

            AddDigitsToList(m1, resultDigits);
            AddDigitsToList(m2, resultDigits);
            AddDigitsToList(product, resultDigits);

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
