using System;
using System.Collections.Generic;

namespace P02.OddOccurrence
{
    class OddOccurrence
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();

                if(!dict.ContainsKey(word))
                {
                    dict[word] = 0;

                }

                dict[word]++;



            }

            foreach (KeyValuePair<string, int> item in dict)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");

                }
            }
        }
    }
}
