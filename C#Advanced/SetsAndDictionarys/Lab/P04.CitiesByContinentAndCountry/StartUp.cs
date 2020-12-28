using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.CitiesByContinentAndCountry
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = input[0];

                string country = input[1];

                string town = input[2];

                if (!dict.ContainsKey(continent))
                {

                    dict[continent] = new Dictionary<string, List<string>>();

                }

                if (!dict[continent].ContainsKey(country))
                {

                    dict[continent].Add(country, new List<string>());

                }

                dict[continent][country].Add(town);
            }

            foreach (var continent in dict)
            {

                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {

                    Console.WriteLine($"  {country.Key} -> {String.Join(", ", country.Value)}");
                }
            }
        }
    }
}
