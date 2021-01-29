using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03.WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //string exprctingResultPath = Path.Combine("..", "..", "..", "actualResults.txt");

            string[] words = File.ReadAllLines("../../../words.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCount.Add(word.ToLower(), 0);
            }

            string text = File.ReadAllText("../../../text.txt").ToLower();
            string[] textWords = text.Split(new string[] { " ", ",", ".", "!", "?", "-", Environment.NewLine }, 
                StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower()).ToArray();

            foreach(string word in textWords)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            List<string> actualResults = wordsCount
                .Select(kvp => $"{kvp.Key} - {kvp.Value}")
                .ToList();

            File.WriteAllLines("../../../acctualResults.txt", actualResults);

            Dictionary<string, int> sortedWords = wordsCount
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(a => a.Key, b => b.Value);

            List<string> outputLines = sortedWords
                .Select(kvp => $"{kvp.Key} - {kvp.Value}")
                .ToList();

            File.WriteAllLines("../../../expectedResult.txt", outputLines);
        }
    }
}
