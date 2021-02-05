using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            FillDictionary(dict, n);

            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    return;
                }
            }
        }

        private static void FillDictionary(Dictionary<int, int> dict, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(num))
                {
                    dict[num] = 1;
                }
                else
                {
                    dict[num]++;
                }

            }
        }
    }
}
