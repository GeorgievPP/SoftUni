using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountSameValuesInArray
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {

                if (!dict.ContainsKey(input[i]))
                {

                    dict[input[i]] = 1;

                }
                else
                {

                    dict[input[i]]++;

                }

            }

            foreach (var kvp in dict)
            {

                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");

            }
        }
    }
}
