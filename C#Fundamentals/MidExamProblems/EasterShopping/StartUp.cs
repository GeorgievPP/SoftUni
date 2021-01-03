using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P03.EasterShopping
{ // 16.04.2019 
    class EasterShopping
    { // 80 / 100
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                string firstCommand = input[1];

                int secondCommand = 0;

                if (input.Length == 3)
                {
                    secondCommand = int.Parse(input[2]);

                }

                if (cmd == "Include")
                {

                    list.Add(firstCommand);

                }
                else if (cmd == "Visit" && secondCommand <= list.Count && secondCommand >= 0)
                {
                    if (firstCommand == "first")
                    {
                        for (int j = 0; j < secondCommand; j++)
                        {
                            list.RemoveAt(0);

                        }
                    }
                    else
                    {
                        for (int j = 0; j < secondCommand; j++)
                        {
                            list.RemoveAt(list.Count - 1);

                        }
                    }
                }
                else if (cmd == "Prefer" && int.Parse(firstCommand) >= 0 && list.Count - 1 >= int.Parse(firstCommand) && secondCommand >= 0 && list.Count - 1 >= secondCommand)
                {
                    string firstShop = list[int.Parse(firstCommand)];

                    string secondShop = list[secondCommand];

                    list[int.Parse(firstCommand)] = secondShop;

                    list[secondCommand] = firstShop;

                }

                else if (cmd == "Place" && list.Count > secondCommand && secondCommand >= 0)
                {
                    list.Insert(secondCommand + 1, firstCommand);

                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
