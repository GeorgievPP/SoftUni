using System;
using System.Collections.Generic;

namespace P03.WordSynonyms
{
    class WordSybonyms
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for( int i = 0; i < n; i ++)
            {
                string word = Console.ReadLine();

                string synonym = Console.ReadLine();

                if( !synonyms.ContainsKey(word))
                {
                    synonyms[word] = new List<string>();

                }

                synonyms[word].Add(synonym);

            }

            foreach(KeyValuePair<string, List<string>> item in synonyms)
            {
                Console.WriteLine($"{item.Key} - " + $"{string.Join(", ", item.Value)}");
            } 
        }
    }
}
