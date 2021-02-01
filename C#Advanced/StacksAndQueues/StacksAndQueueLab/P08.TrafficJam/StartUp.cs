using System;
using System.Collections.Generic;

namespace P08.TrafficJam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int greenPassedCount = int.Parse(Console.ReadLine());
            int totalCarPassedCount = 0;

            Queue<string> cars = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < greenPassedCount; i++)
                    {
                        if (cars.Count == 0) break;

                        totalCarPassedCount++;

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(command);

                }
            }

            Console.WriteLine($"{totalCarPassedCount} cars passed the crossroads.");
        }
    }
}
