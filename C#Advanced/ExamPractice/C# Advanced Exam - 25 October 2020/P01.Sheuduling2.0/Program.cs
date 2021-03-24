using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Sheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stackInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] queueInput = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();

            int magicTask = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(stackInput);
            Queue<int> queue = new Queue<int>(queueInput);

            while (true)
            {
                int task = stack.Peek();
                int thread = queue.Peek();

                if(task == magicTask)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {task}");
                    Console.WriteLine(String.Join(" ", queue));
                    return;
                }

                if(thread >= task)
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else if(thread < task)
                {
                    queue.Dequeue();
                }
            }

        }
    }
}
