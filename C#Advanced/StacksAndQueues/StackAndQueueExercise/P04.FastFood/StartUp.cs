using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int foodForDay = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            int maxOrder = queue.Max();

            int sum = 0;

            Console.WriteLine(maxOrder);

            while(queue.Count > 0)
            {
                int firsInQueue = queue.Peek();

                sum += firsInQueue;

                if(sum <= foodForDay)
                {

                    queue.Dequeue();

                    continue;

                }
                else
                {

                    int[] ordersLeft = queue.ToArray();

                    Console.WriteLine("Orders left: " + string.Join(" ", ordersLeft));

                    return;
                }

            }

            Console.WriteLine("Orders complete");

        }
    }
}
