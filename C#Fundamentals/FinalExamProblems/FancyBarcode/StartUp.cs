using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem02.FancyBarcode
{
    class Program
    {
        static void Main(string[] args)
         {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"@#+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if(match.Success)
                {
                    string str = match.Groups["product"].Value;

                    int number;

                    for (int j = 0; j < str.Length; j++)
                    {


                        if(char.IsDigit(str[j]))
                        {
                            sb.Append(str[j]);
                        }
                    }

                    if(sb.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");

                        
                    }
                    else
                    {
                       // number = int.Parse(sb.ToString());

                        Console.WriteLine($"Product group: {sb.ToString()}");

                        
                    }

                    sb.Clear();
                }

                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }



        }
    }
}
