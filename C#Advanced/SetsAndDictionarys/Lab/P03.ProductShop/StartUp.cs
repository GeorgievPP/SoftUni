using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ProductShop
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {

                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "Revision")
                {

                    break;

                }

                string shop = input[0];

                string product = input[1];

                double price = double.Parse(input[2]);

                if (!dict.ContainsKey(shop))
                {

                    dict[shop] = new Dictionary<string, double>();

                    dict[shop][product] = price;

                }

                else
                {

                    if (!dict[shop].ContainsKey(product))
                    {

                        dict[shop][product] = price;
                    }

                }

            }

            dict = dict.OrderBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in dict)
            {

                Console.WriteLine($"{ kvp.Key}->");

                foreach (var item in kvp.Value)
                {

                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");

                }
            }

        }
    }
}
