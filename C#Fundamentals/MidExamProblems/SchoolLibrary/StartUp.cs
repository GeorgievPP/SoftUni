using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.SchoolLibrary
{
    class SchoolLibrary
    { // 10.DEC.2019
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split('&', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while( command != "Done")
            {
                string[] input = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];
                if(cmd == "Add Book")
                {
                    string book = input[1];

                    if(!list.Contains(book))
                    {
                        list.Insert(0, book);

                    }
                }
                else if(cmd == "Take Book")
                {
                    string book = input[1];

                    if(list.Contains(book))
                    {
                        list.Remove(book);

                    }
                }
                else if( cmd == "Swap Books")
                {
                    string book1 = input[1];
                    string book2 = input[2];

                    if(list.Contains(book1) && list.Contains(book2))
                    {
                        int index = list.IndexOf(book1);

                        int index2 = list.IndexOf(book2);

                        list[index] = book2;
                        list[index2] = book1;

                    }
                }
                else if(cmd == "Insert Book")
                {
                    string book = input[1];
                    list.Add(book);

                }
                else if(cmd == "Check Book")
                {
                    int index = int.Parse(input[1]);

                    if(index >= 0 && index < list.Count)
                    {
                        string current = list[index];
                        Console.WriteLine(current);

                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));

        }
    }
}
