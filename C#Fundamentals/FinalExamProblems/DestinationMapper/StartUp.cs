using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<symbol>\=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);

            int points = 0;

            List<string> destinations = new List<string>();

            foreach (Match match in matches)
            {
                string destination = match.Groups["destination"].Value;

                destinations.Add(destination);

                points += destination.Length;

            }

            if (destinations.Count == 0)
            {
                Console.WriteLine("Destinations:");

                //Console.WriteLine(string.Join(", ", destinations));

                Console.WriteLine($"Travel Points: {points}");
            }
            else
            {
                Console.WriteLine($"Destinations: {(string.Join(", ", destinations))}");

               // Console.WriteLine(string.Join(", ", destinations));

                Console.WriteLine($"Travel Points: {points}");
            }


        }
    }
}
