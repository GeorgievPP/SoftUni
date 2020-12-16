using System;
using System.Linq;

namespace P05.WordFilter
{
    class WordFilter
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] wordsWithoutOdd = words.Where(word => word.Length % 2 == 0).ToArray();

            Console.WriteLine(string.Join('\n', wordsWithoutOdd));
        }
    }
}
