using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06.Wardrobe
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];

                string[] clothes = input[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!dict.ContainsKey(color))
                {
                    //dict[color] = new Dictionary<string, int>();

                    dict.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!dict[color].ContainsKey(item))
                    {
                        //dict[color][clothes] = 0;

                        dict[color].Add(item, 0);
                    }

                    dict[color][item]++;
                }

            }

            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string targetColor = arr[0];
            string element = arr[1];

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var item in kvp.Value)
                {
                    StringBuilder sb = new StringBuilder($"* {item.Key} - {item.Value}");

                    if (kvp.Key == targetColor && item.Key == element)
                    {
                        sb.Append(" (found!)");
                    }

                    Console.WriteLine(sb.ToString());

                }

            }

        }
    }
}
