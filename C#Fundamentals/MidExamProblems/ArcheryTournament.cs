using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcheryTournament
{ // 10.12.2019
    class ArcheryTournament
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            int iskrenPoint = 0;

            while( command != "Game over")
            {
                if(command == "Reverse")
                {
                    list.Reverse();

                    command = Console.ReadLine();

                    continue;


                }

                string[] input = command.Split('@').ToArray();

                string direction = input[0];

                int startIndex = int.Parse(input[1]);

                int length = int.Parse(input[2]);

                int listLength = list.Count();

                if(startIndex >= listLength || startIndex < 0)
                {
                    command = Console.ReadLine();
                    continue;

                }

                if(direction == "Shoot Left")
                {
                    while(length > 0)
                    {
                        if (startIndex <= 0)
                        {
                            startIndex = listLength;

                        }

                        startIndex--;
                        length--;

                    }
                    if(list[startIndex] < 5)
                    {
                        iskrenPoint += list[startIndex];

                        list[startIndex] = 0;

                    }
                    else
                    {
                        list[startIndex] -= 5;

                        iskrenPoint += 5;

                    }
                }
                else if( direction == "Shoot Right")
                {
                    while(length > 0)
                    {
                        if(startIndex == listLength)
                        {
                            startIndex = 0;

                        }

                        startIndex++;
                        length--;

                    }
                    if(list[startIndex] < 5)
                    {
                        iskrenPoint += list[startIndex];

                        list[startIndex] = 0;

                    }
                    else
                    {
                        list[startIndex] -= 5;
                        iskrenPoint += 5;

                    }

                }

                command = Console.ReadLine();

            }

            Console.WriteLine(string.Join(" - ", list));

            Console.WriteLine($"Iskren finished the archery tournament with {iskrenPoint} points!");

        }
    }
}
