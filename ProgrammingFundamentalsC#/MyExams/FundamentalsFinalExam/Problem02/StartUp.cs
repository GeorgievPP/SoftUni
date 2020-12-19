using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem02
{
    class StartUp
    { // 100/100
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"(!)([A-Z][a-z]{2,})\1\:\[(?<message>[A-Za-z]{8,})\]";

            List<int> encrMess = new List<int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if(match.Success)
                {
                    string message = match.Groups["message"].Value;

                    string cmd = match.Groups[2].Value;

                    foreach(char ch in message)
                    {
                        encrMess.Add(ch);
                    }


                    Console.WriteLine($"{cmd}: {string.Join(" ", encrMess)}");

                    continue;

                }

                else
                {
                    Console.WriteLine("The message is invalid");

                    continue;
                }
            }
        }
    }
}
