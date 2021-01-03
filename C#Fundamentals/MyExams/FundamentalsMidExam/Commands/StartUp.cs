using System;
using System.Collections.Generic;
using System.Linq;

namespace Commands
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string commmand = Console.ReadLine();

            while(commmand != "end")
            {
                string[] input = commmand.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(input.Length > 2)
                {
                    string cmd = input[0];
                    if(cmd == "reverse")
                    {
                        int startIndex = int.Parse(input[2]);

                        int count = int.Parse(input[4]);

                        List<string> reversedList = new List<string>();

                        for(int i = 0; i < count; i++)
                        {
                            reversedList.Add(list[startIndex + i]);

                        }

                        reversedList.Reverse();

                        list.RemoveRange(startIndex, count);

                        list.InsertRange(startIndex, reversedList);

                    }
                    else if(cmd == "sort")
                    {
                        int startIndex = int.Parse(input[2]);

                        int count = int.Parse(input[4]);

                        List<string> newSortList = new List<string>();

                        for(int i = 0; i < count; i++)
                        {
                            newSortList.Add(list[startIndex + i]);

                        }

                        newSortList.Sort();

                        list.RemoveRange(startIndex, count);

                        list.InsertRange(startIndex, newSortList);
                    }
                }
                else
                {
                    int count = int.Parse(input[1]);


                    list.RemoveRange(0, count);
                }


                commmand = Console.ReadLine();

            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
