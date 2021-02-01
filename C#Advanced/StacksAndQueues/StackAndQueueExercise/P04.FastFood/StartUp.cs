using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P04.FastFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int foodForDay = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            int maxOrder = queue.Max();
            Console.WriteLine(maxOrder);

            while (queue.Count > 0)
            {
                int firsInQueue = queue.Peek();
                sum += firsInQueue;

                if (sum <= foodForDay)
                {
                    queue.Dequeue();
                    continue;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("Orders left: ");
                sb.Append(string.Join(" ", queue));

                Console.WriteLine(sb.ToString());
                return;
            }

            Console.WriteLine("Orders complete");
        }
    }
}
