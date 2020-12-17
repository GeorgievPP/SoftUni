using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem01.Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            List<string> furnitures = new List<string>();

            decimal totalMoneySpend = 0.0m;

            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            string input;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if(match.Success)
                {
                    string name = match.Groups["name"].Value;

                    decimal price = decimal.Parse(match.Groups["price"].Value);

                    long quantity = long.Parse(match.Groups["quantity"].Value);

                    furnitures.Add(name);

                    totalMoneySpend += (price * quantity);

                }
            }

            Console.WriteLine("Bought furniture:");

            foreach(var name in furnitures)
            {
                Console.WriteLine(name);

            }

            Console.WriteLine($"Total money spend: {totalMoneySpend:f2}");
           

        }
    }
}
