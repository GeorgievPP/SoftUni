using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace P03.HeartDelivery
{
    class HearDelivery
    { // 29.02.2020 Group2
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int counter = 0;

            int currentIndex = 0;

            int notValDay = 0;

            while (command[0] != "Love!")
            {
                if (command[0] == "Jump")
                {
                    int jump = int.Parse(command[1]);

                    currentIndex = jump + currentIndex;

                    if (currentIndex > list.Count - 1)
                    {
                        currentIndex = 0;

                    }
                    if (list[currentIndex] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex} already had Valentine's day.");

                    }
                    else
                    {
                        int currentNeighboor = list[currentIndex];

                        list.Insert(currentIndex, currentNeighboor - 2);

                        list.RemoveAt(currentIndex + 1);

                        counter = currentIndex;

                        if (list[currentIndex] == 0)
                        {
                            Console.WriteLine($"Place {counter} has Valentine's day.");
                        }

                        if (list[currentIndex] < 0)
                        {
                            list[currentIndex] = 0;
                        }

                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0)
                {
                    notValDay++;

                }
            }

            Console.WriteLine($"Cupid's last position was {currentIndex}.");

            if (list.All(n => n == 0))
            {
                Console.WriteLine("Mission was successful.");

            }
            else
            {
                Console.WriteLine($"Cupid has failed {notValDay} places.");
            }
        }
    }
}
