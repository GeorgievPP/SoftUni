using System;

namespace VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            int conter = 0;

            conter = GetVowels(word, conter);

            Console.WriteLine(conter);

        }

        private static int GetVowels(string word, int conter)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char symbol = word[i];
                if (symbol == 'a' || symbol == 'i' || symbol == 'e' || symbol == 'o' || symbol == 'y' || symbol == 'u')
                {
                    conter++;

                }

            }

            return conter;
        }

    }
}
