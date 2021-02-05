using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P01.CountSameValuesInArray
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            double[] doubleCollection = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            for (int i = 0; i < doubleCollection.Length; i++)
            {
                if (!dict.ContainsKey(doubleCollection[i]))
                {
                    dict[doubleCollection[i]] = 1;
                }
                else
                {
                    dict[doubleCollection[i]]++;
                }
            }

            foreach (var kvp in dict)
            {
                sb.AppendLine($"{kvp.Key} - {kvp.Value} times");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
