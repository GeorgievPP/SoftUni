using System;

namespace P03.Substring
{
    class Substring
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine().ToLower();

            string text = Console.ReadLine();

            while(text.Contains(wordToRemove))
            {
                int startIndex = text.IndexOf(wordToRemove);

                text = text.Remove(startIndex, wordToRemove.Length);

            }

            Console.WriteLine(text);

        }
    }
}
