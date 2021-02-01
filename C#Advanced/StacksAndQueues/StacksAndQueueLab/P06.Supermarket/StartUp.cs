using System;
using System.Collections.Generic;

namespace P06.Supermarket
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> queueOfCostumers = new Queue<string>();

            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                if (name == "Paid")
                {
                    PrintPaidCostumers(queueOfCostumers);
                    continue;
                }

                queueOfCostumers.Enqueue(name);
            }

            Console.WriteLine($"{queueOfCostumers.Count} people remaining.");
        }

        private static void PrintPaidCostumers(Queue<string> queueOfCostumers)
        {
            while (queueOfCostumers.Count > 0)
            {
                Console.WriteLine(queueOfCostumers.Dequeue());
            }
        }
    }
}
