using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.Sheduling2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(taskInput);

            int[] threadInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(threadInput);

            int targetTask = int.Parse(Console.ReadLine());
            int threadKiller = 0;

            while (true)
            {
                int currentTask = stack.Peek();
                int currentThread = queue.Peek();

                if (currentTask == targetTask)
                {
                    threadKiller = currentThread;
                    break;
                }

                if (currentTask > currentThread)
                {
                    queue.Dequeue();
                    continue;
                }
                else
                {
                    stack.Pop();
                    queue.Dequeue();
                    continue;
                }

            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Thread with value {threadKiller} killed task {targetTask}")
              .AppendLine(String.Join(" ", queue));

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
