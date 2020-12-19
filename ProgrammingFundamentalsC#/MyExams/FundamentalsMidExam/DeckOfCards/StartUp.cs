using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                if( cmd == "Add")
                {
                    string cardName = input[1];

                    if(list.Contains(cardName))
                    {
                        Console.WriteLine("Card is already bought");

                    }
                    else
                    {
                        Console.WriteLine("Card successfully bought");

                        list.Add(cardName);

                    }
                }
                else if(cmd == "Remove")
                {
                    string cardName = input[1];

                    if (list.Contains(cardName))
                    {
                        Console.WriteLine("Card successfully sold");

                        list.Remove(cardName);

                    }
                    else
                    {
                        Console.WriteLine("Card not found");
                    }
                }
                else if(cmd =="Remove At")
                {
                    int index = int.Parse(input[1]);

                    if(index >= 0 && index < list.Count)
                    {
                        list.RemoveAt(index);

                        Console.WriteLine("Card successfully sold");

                    }
                    else
                    {
                        Console.WriteLine("Index out of range");

                    }
                }
                else if (cmd == "Insert")
                {
                    int index = int.Parse(input[1]);

                    string cardName = input[2];

                    if ((index >= 0 && index < list.Count) && list.Contains(cardName))
                    {
                        Console.WriteLine("Card is already bought");

                    }
                    else if ((index >= 0 && index < list.Count) && !list.Contains(cardName))
                    {
                        list.Insert(index, cardName);

                        Console.WriteLine("Card successfully bought");
                    }
                    else if (index < 0 || index >= list.Count)
                    {
                        Console.WriteLine("Index out of range");

                    }
                }
               

            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
