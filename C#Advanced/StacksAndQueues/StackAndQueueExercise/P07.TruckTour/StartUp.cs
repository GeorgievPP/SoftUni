using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem07.TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            FillQueue(n, pumps);

            int count = 0;

            while(true)
            {

                int fuelAmount = 0;

                bool foundPoint = true;

                for(int i = 0; i < n; i++)
                {

                    int[] currPump = pumps.Dequeue();

                    fuelAmount += currPump[0];

                    if(fuelAmount < currPump[1])
                    {

                        foundPoint = false;

                    }

                    fuelAmount -= currPump[1];

                    pumps.Enqueue(currPump);

                }

                if(foundPoint)
                {
                    break;
                }

                count++;

                pumps.Enqueue(pumps.Dequeue());

            }

            Console.WriteLine(count);

        }

        private static void FillQueue(int n, Queue<int[]> pumps)
        {
            for(int i = 0; i < n; i++)
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
