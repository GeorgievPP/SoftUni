using System;
using System.Text.RegularExpressions;

namespace Problem03.SoftUniBar
{
    class SoftUniBar
    {
        static void Main(string[] args)
        {
            decimal totalIncome = 0.0m;

            string pattern = @"%(?<costumer>[A-Z]{1}[a-z]+)%[^|$%\.]*<(?<product>\w+)>[^|$%\.]*\|(?<count>\d+)\|[^|$%\.]*?(?<price>\d+\.?\d*)\$";

            string input;

            while((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if(match.Success)
                {
                    string costumer = match.Groups["costumer"].Value;

                    string product = match.Groups["product"].Value;

                    long count = long.Parse(match.Groups["count"].Value);

                    decimal price = decimal.Parse(match.Groups["price"].Value);

                    if(count != 0)
                    {
                        decimal totalPrice = price * count;

                        totalIncome += totalPrice;

                        Console.WriteLine($"{costumer}: {product} - {totalPrice:f2}");

                    }
                }

            }

            Console.WriteLine($"Total income: {totalIncome:f2}");


        }
    }
}
