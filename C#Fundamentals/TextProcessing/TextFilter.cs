using System;
using System.Linq;

namespace P04.TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string text = Console.ReadLine();

            for(int i = 0; i < bannedWords.Length; i++)
            {

                string wordToCensor = bannedWords[i];

                while(text.Contains(wordToCensor))
                {
                    text = text.Replace(wordToCensor, new string('*', wordToCensor.Length));

                    // string wordToReplace = new string('*', wordToCensor.Length);

                }
            }

            Console.WriteLine(text);
        }
    }
}
