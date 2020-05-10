using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _079_Passcode_derivation
{
    class Program
    {
        static void Main(string[] args)
        {
            //A common security method used for online banking is to ask the user for three random characters from a passcode. 
            //For example, if the passcode was 531278, they may ask for the 2nd, 3rd, and 5th characters; the expected reply would be: 317.

            //The text file, keylog.txt, contains fifty successful login attempts.

            //Given that the three characters are always asked for in order, 
            //analyse the file so as to determine the shortest possible secret passcode of unknown length.

            const string filename = "keylog.txt";
            List<int[]> logins = new List<int[]>();
            List<passcodeDigit> passcodeDigits = Enumerable.Range(0, 10).Select(x => new passcodeDigit(x)).ToList();
            var r = new StreamReader(filename);
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                int[] digits = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    digits[i] = int.Parse(line[i].ToString());
                }
                logins.Add(digits);
            }
            r.Close();

            foreach (int[] login in logins)
            {
                for (int i = 0; i < login.Length; i++)
                {
                    for (int j = i + 1; j < login.Length; j++)
                    {
                        passcodeDigits[login[i]].DigitsAfter.Add(login[j]);
                    }
                    for (int j = i-1; j >= 0; j--)
                    {
                        passcodeDigits[login[i]].DigitsBefore.Add(login[j]);
                    }
                }
            }

            var sortedDigits = passcodeDigits.Where(x => x.DigitsAfter.Any() || x.DigitsBefore.Any()).OrderBy(x => x.DigitsBefore.Distinct().Count());
            foreach (passcodeDigit passcodeDigit in sortedDigits)
            {
                Console.Write(passcodeDigit.Digit);
            }



            Console.Read();
        }
    }

    class passcodeDigit
    {
        public int Digit { get; set; }
        public List<int> DigitsBefore { get; set; }
        public List<int> DigitsAfter { get; set; }

        public passcodeDigit(int digit)
        {
            Digit = digit;
            DigitsAfter = new List<int>();
            DigitsBefore = new List<int>();
        }
    }
}
