using System;
using System.Collections.Generic;

namespace P05.CountSymbols
{
    class StartUp
    {
        static void Main(string[] args)
        {

            char[] input = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            FillDictionary(input, dict);

            foreach (var kvp in dict)
            {

                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");

            }

        }

        private static void FillDictionary(char[] arr, SortedDictionary<char, int> dict)
        {
            for (int i = 0; i < arr.Length; i++)
            {

                if (!dict.ContainsKey(arr[i]))
                {

                    dict[arr[i]] = 1;
                }

                else
                {

                    dict[arr[i]]++;

                }
            }
        }
    }
}
