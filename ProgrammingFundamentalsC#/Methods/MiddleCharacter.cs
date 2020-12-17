using System;
using System.Text;

namespace Problem06.MiddleCharacter
{
    class MiddleCharacter
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int length = input.Length;
            string word = "";

            word = GetMIddle(input, length, word);

            Console.WriteLine(word);


        }

        private static string GetMIddle(string input, int length, string word)
        {
            if (length % 2 == 0)
            {
                for (int i = (length / 2)-1 ; i <= (length / 2); i++)
                {
                    word += input[i];
                }
            }
            else
            {
                word += input[(length / 2)];

            }

            return word;
        }
    }
}
