using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022_Names_Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using names.txt, 
            //a 46K text file containing over five-thousand first names, 
            //begin by sorting it into alphabetical order. 
            //Then working out the alphabetical value for each name, 
            //multiply this value by its alphabetical position in the list to obtain a name score.

            //For example, when the list is sorted into alphabetical order, 
            //COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
            //So, COLIN would obtain a score of 938 × 53 = 49714.

            //What is the total of all the name scores in the file?

            string filename = "names.txt";
            List<string> names = readInput(filename).ToList();

            names.Sort();

            int testIndex = 937;
            Console.WriteLine(names[testIndex]); //posistion = index + 1   -   because 0 indexed
            Console.WriteLine( NameScore(names[testIndex], testIndex));

            long sum = 0;

            for (int i = 0; i < names.Count; i++)
            {
                sum += NameScore(names[i], i);
            }
            Console.Write(sum);

            Console.Read();

        }

        public static string[] readInput(string filename)
        {
            StreamReader r = new StreamReader(filename);
            string line = r.ReadToEnd();
            r.Close();

            string[] names = line.Split(',');

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Trim('"');
            }

            return names;
        }

        public static int AlphaValue(string name)
        {
            int value = 0;
            foreach (char letter in name)
            {
                value += Convert.ToInt32(letter) - 64; //ascii - 64 = letter value
            }
            return value;
        }

        public static int NameScore(string name, int index)
        {
            return AlphaValue(name) * (index + 1);      //posistion = index + 1    because 0 indexed
        }
    }
}
