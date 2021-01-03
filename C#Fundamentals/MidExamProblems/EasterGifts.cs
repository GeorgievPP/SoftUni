using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.EasterGifts
{
    class EasterGifts
    {
        static void Main(string[] args)
        { // 16.April.2019

            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while(command != "No Money")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];
                string gift = input[1];

                if (cmd == "OutOfStock")
                {
                    

                    while(list.Contains(gift))
                    {
                        int index = list.IndexOf(gift);

                        list[index] = "None";

                    }
                }

                else if (cmd == "Required")
                {
                    

                    int index = int.Parse(input[2]);

                    if (index >= 0 && index < list.Count)
                    {
                        list[index] = gift;
                    }
                }
                else if (cmd == "JustInCase")
                {

                    list[list.Count - 1] = gift;



                }

                command = Console.ReadLine();
            }

            while(list.Contains("None"))
            {
                list.Remove("None");
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
