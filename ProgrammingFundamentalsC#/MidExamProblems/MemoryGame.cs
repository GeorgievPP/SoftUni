using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace P03.MemoryGame
{
    class MemoryGame
    {// 12.August.2020
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            int count = 0;

            bool victory = false;


            while(input != "end")
            {
                string[] arr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                int index1 = int.Parse(arr[0]);
                int index2 = int.Parse(arr[1]);

                count++;

                if ((index1 == index2 ) || ((index1 < 0 || index1 > list.Count -1) || ( index2 < 0 || index2 > list.Count -1)))
                {
                    string addEll = "-" + count.ToString() + "a";

                    int index = list.Count / 2;

                    list.Insert(index, addEll);
                    list.Insert(index, addEll);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                }
                else if ( (index1 >=0 && index2< list.Count) && (index2 >= 0 && index2 < list.Count))
                {
                    if (list[index1] == list[index2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {list[index1]}!");

                        int big = (Math.Max(index1, index2));
                        int small = (Math.Min(index1, index2));

                        list.RemoveAt(small);
                        list.RemoveAt(big - 1);

                    }
                    else
                    {
                        Console.WriteLine("Try again!");

                    }
                }
                if (list.Count == 0)
                {
                    victory = true;
                    break;
                }

                input = Console.ReadLine();


            }

            if (victory)
            {
                Console.WriteLine($"You have won in {count} turns!");

            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}
