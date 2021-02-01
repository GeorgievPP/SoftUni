using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem07.TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfPumps = 0;
            int petrolPumps = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();
            FillQueue(pumps, petrolPumps);

            while (true)
            {
                int fuelAmount = 0;
                bool foundPoint = true;

                for (int i = 0; i < petrolPumps; i++)
                {
                    int[] currPump = pumps.Dequeue();
                    int petrolPump = currPump[0];
                    fuelAmount += petrolPump;
                    int distance = currPump[1];

                    if (fuelAmount < distance)
                    {
                        foundPoint = false;
                    }

                    fuelAmount -= distance;

                    pumps.Enqueue(currPump);
                }

                if (foundPoint)
                {
                    break;
                }

                countOfPumps++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(countOfPumps);
        }

        private static void FillQueue(Queue<int[]> pumps, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int[] currPump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currPump);
            }
        }
    }
}
