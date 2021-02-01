using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P02
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] engineNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberstToFillCount = engineNumbers[0];
            int numbersToRemoveCount = engineNumbers[1];
            int specialNumber = engineNumbers[2];

            int[] numbersToEnqueue = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();
            FillQueue(numbersToEnqueue, queue, numberstToFillCount);
            RemoveFromQueue(queue, numbersToRemoveCount);
            IsQueueContainsSpecialNumber(queue, specialNumber);
        }

        private static void FillQueue(int[] numbersToEnqueue, Queue<int> queue, int count)
        {
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(numbersToEnqueue[i]);
            }
        }

        private static void RemoveFromQueue(Queue<int> queue, int count)
        {
            for (int i = 0; i < count; i++)
            {
                queue.Dequeue();
            }
        }

        private static void IsQueueContainsSpecialNumber(Queue<int> queue, int specialNumber)
        {
            StringBuilder sb = new StringBuilder();

            if (queue.Contains(specialNumber))
            {
                sb.Append("true");
            }
            else
            {
                int smallestNumber = queue.Count > 0 ? queue.Min() : 0;
                sb.Append(smallestNumber);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
