using System;
using System.Collections.Generic;

namespace P01.CountCharsInString
{
    class CountCharsInString
    {
        static void Main(string[] args)
        {
            Dictionary<char, uint> historgam = new Dictionary<char, uint>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i ++)
            {
                char currChar = text[i];

                if(currChar != ' ')
                {
                    if(!historgam.ContainsKey(currChar))
                    {
                        historgam[currChar] = 0;

                    }
                    historgam[currChar]++;

                }
            }

            foreach(KeyValuePair<char, uint> kvp in historgam)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
