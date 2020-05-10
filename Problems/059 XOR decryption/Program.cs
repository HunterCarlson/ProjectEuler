using System;
using MyMathFunctions;

namespace _059_XOR_decryption
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Each character on a computer is assigned a unique code and the preferred standard is ASCII 
            //(American Standard Code for Information Interchange). For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.

            //A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, 
            //taken from a secret key. The advantage with the XOR function is that using the same encryption key on the cipher text, 
            //restores the plain text; for example, 65 XOR 42 = 107, then 107 XOR 42 = 65.

            //For unbreakable encryption, the key is the same length as the plain text message, and the key is made up of random bytes. 
            //The user would keep the encrypted message and the encryption key in different locations, and without both "halves", 
            //it is impossible to decrypt the message.

            //Unfortunately, this method is impractical for most users, so the modified method is to use a password as a key. 
            //If the password is shorter than the message, which is likely, the key is repeated cyclically throughout the message. 
            //The balance for this method is using a sufficiently long password key for security, but short enough to be memorable.

            //Your task has been made easy, as the encryption key consists of three lower case characters. Using cipher1.txt, 
            //a file containing the encrypted ASCII codes, and the knowledge that the plain text must contain common English words, 
            //decrypt the message and find the sum of the ASCII values in the original text.

            const string filename = "cipher1.txt";
            string[] cipherCharStrings = MathFunctions.ReadCsvFile(filename);
            int[] cipher = CipherToIntArray(cipherCharStrings);

            GuessKey(cipher);

            Console.WriteLine("Done");
            Console.Read();
        }

        public static void Decrypt(int[] cipher, string key)
        {
            int keyIndex = 0;
            int asciiSum = 0;
            string plaintext = String.Empty;
            foreach (int c in cipher)
            {
                var plainchar = (char) (c ^ key[keyIndex]);
                if (plainchar < 32 || plainchar > 126
                    || plainchar == '$' || plainchar == '#') //if char not in normal ascii
                {
                    break;
                }
                plaintext += plainchar;
                asciiSum += plainchar;
                keyIndex = (keyIndex + 1)%key.Length;
            }
            if (plaintext.Length == cipher.Length && plaintext.Contains("the"))
            {
                Console.WriteLine("Key: {0}\n", key);
                Console.WriteLine("Plaintext: \n{0}\n", plaintext);
                Console.WriteLine("ASCII sum = {0}", asciiSum);
            }
        }

        public static void GuessKey(int[] cipher)
        {
            const int start = 'a';
            const int end = 'z';

            for (int char1 = start; char1 <= end; char1++)
            {
                for (int char2 = start; char2 <= end; char2++)
                {
                    for (int char3 = start; char3 <= end; char3++)
                    {
                        char[] chars = {(char) char1, (char) char2, (char) char3};
                        var key = new string(chars);
                        Decrypt(cipher, key);
                    }
                }
            }
        }

        public static int[] CipherToIntArray(string[] intStrings)
        {
            var ints = new int[intStrings.Length];
            for (int i = 0; i < intStrings.Length; i++)
            {
                ints[i] = int.Parse(intStrings[i]);
            }
            return ints;
        }
    }
}