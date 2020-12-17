using System;
using System.Linq;

namespace P02.RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                for(int j = 0; j < word.Length; j++)
                {
                    Console.Write(word);

                }
            }
        }
    }
}
