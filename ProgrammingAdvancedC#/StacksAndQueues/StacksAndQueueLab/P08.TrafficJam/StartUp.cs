using System;
using System.Collections.Generic;

namespace P08.TrafficJam
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int greenCount = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int count = 0;

            string command;

            while((command = Console.ReadLine()) != "end")
            {

                if(command == "green")
                {
                    for(int i = 0; i < greenCount; i++)
                    {
                        if (cars.Count == 0) break;

                        count++;

                        Console.WriteLine($"{cars.Dequeue()} passed!");

                    }

                }
                else
                {
                    cars.Enqueue(command);

                }


            }

            Console.WriteLine($"{count} cars passed the crossroads.");

        }
    }
}
