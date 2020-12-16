using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CounRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();


            SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();


            for(int i = 0; i < numbers.Count; i++)
            {
                if(!dictionary.ContainsKey(numbers[i]))
                {
                    dictionary.Add(numbers[i], 1);
                }
                else
                {
                    dictionary[numbers[i]]++;

                }
            }

            foreach(KeyValuePair<double, int> item in dictionary)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
