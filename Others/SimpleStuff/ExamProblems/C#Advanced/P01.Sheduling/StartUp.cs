using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Sheduling
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int[] tasksInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> tasks = new Stack<int>(tasksInput);


            int[] threadsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> threads = new Queue<int>(threadsInput);

            int valueOfTask = int.Parse(Console.ReadLine());

            int killerOfTask = 0;

            string threadsResult = "";

            while (true)
            {

                int currentTask = tasks.Peek();

                int currentThread = threads.Peek();

                if (currentTask == valueOfTask)
                {

                    killerOfTask = currentThread;

                    threadsResult = String.Join(" ", threads);

                    break;

                }

                if (currentThread >= currentTask)
                {

                    tasks.Pop();

                    threads.Dequeue();

                    continue;

                }

                else
                {

                    threads.Dequeue();

                    continue;

                }

            }

            Console.WriteLine($"Thread with value {killerOfTask} killed task {valueOfTask}");

            Console.WriteLine(threadsResult);

        }
    }
}
