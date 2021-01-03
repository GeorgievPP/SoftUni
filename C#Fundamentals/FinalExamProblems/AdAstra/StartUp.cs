using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem02.AdAstra
{
    class StartUp
    { 
        static void Main(string[] args)
        {   //100/100

            string pattern = @"(#|\|)(?<product>[A-Za-z ]+)\1(?<date>([0-2][0-9]|[3][0-1])\/([0][1-9]|[1][0-2])\/[0-9][0-9])\1(?<calories>\d+)\1";

            string input = Console.ReadLine();

            Dictionary<string, string> productDate = new Dictionary<string, string>();

            Dictionary<string, int> productCalories = new Dictionary<string, int>();

            MatchCollection matches = Regex.Matches(input, pattern);

            int totalCal = 0;


            if (matches.Count == 0)
            {
                Console.WriteLine("You have food to last you for: 0 days!");

                return;
            }
            else
            {
                
                foreach (Match match in matches)
                {
                    int calories = int.Parse(match.Groups["calories"].Value);


                    totalCal += calories;

                }

            }

            double days = Math.Floor(totalCal / 2000.0);

            Console.WriteLine($"You have food to last you for: {days} days!");

           foreach(Match match in matches)
            {
               string product = match.Groups["product"].Value;
               int calories = int.Parse(match.Groups["calories"].Value);
               string date = match.Groups["date"].Value;

                Console.WriteLine($"Item: {product}, Best before: {date}, Nutrition: {calories}");

            }


        }
    }
}
