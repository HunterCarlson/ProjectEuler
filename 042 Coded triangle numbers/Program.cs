using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathFunctions;

namespace _042_Coded_triangle_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //The nth term of the sequence of triangle numbers is given by,
            //tn = ½n(n+1); so the first ten triangle numbers are:

            //1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

            //By converting each letter in a word to a number corresponding to its alphabetical position 
            //and adding these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. 
            //If the word value is a triangle number then we shall call the word a triangle word.

            //Using words.txt (right click and 'Save Link/Target As...'), 
            //a 16K text file containing nearly two-thousand common English words, how many are triangle words?

            string filename = "words.txt";
            List<string> words = MathFunctions.ReadCsvFile(filename).ToList();

            Console.WriteLine("there are {0} words in words.txt", words.Count);
            Console.WriteLine("the longest word is {0} letters long", words.Max(word => word.Length));

            //longest word is 14 letters so only need triangle numbers up to 14*26
            //14*26 = 364
            const int triangleLimit = 364;

            int[] triangleNums = new int[triangleLimit + 1];
            for (int i = 1; i <= triangleLimit; i++)
            {
                triangleNums[i] = NthTriangleNumber(i); 
            }

            Console.WriteLine("the first 10 triangle nums are:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(triangleNums[i]);
            }

            int triangleWordCount = 0;
            foreach (string word in words)
            {
                int wordValue = MathFunctions.AlphaValueSum(word);
                if (triangleNums.Contains(wordValue))
                {
                    triangleWordCount++;
                }
            }
            Console.WriteLine("there are {0} triangle words in the list", triangleWordCount);
            
            Console.Read();
        }

        public static int NthTriangleNumber(int n)
        {
            //t(n) = ½n(n+1)
            return (int)((.5 * n) * (n + 1));
        }

    }
}
