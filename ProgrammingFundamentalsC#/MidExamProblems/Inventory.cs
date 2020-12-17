using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Inventory
    {  // 29.02.2020 Group1
        static void Main(string[] args)
        {
            List<string> colection = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();


            while (input != "Craft!")
            {
                string[] arrOfInput = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = arrOfInput[0];

                string item = arrOfInput[1];

                if (command == "Collect")
                {

                    if (!colection.Contains(item))
                    {
                        colection.Add(item);
                    }
                }
                else if (command == "Drop")
                {

                    if (colection.Contains(item))
                    {
                        colection.Remove(item);
                    }
                }
                else if (command == "Combine Items")
                {
                    string[] items = item.Split(':').ToArray();
                    string oldItem = items[0];
                    string newItem = items[1];

                    if (colection.Contains(oldItem))
                    {
                        int index = colection.IndexOf(oldItem);

                        if (index + 1 == colection.Count)
                        {
                            colection.Add(newItem);
                        }
                        else
                        {
                            colection.Insert(index + 1, newItem);
                        }


                    }

                }
                else if (command == "Renew")
                {
                    if (colection.Contains(item))
                    {
                        colection.Remove(item);
                        colection.Add(item);
                    }

                }

                input = Console.ReadLine();


            }

            Console.WriteLine(string.Join(", ", colection));
        }
    }
}
