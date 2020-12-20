using System;
using System.Collections.Generic;

namespace P06.Supermarket
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string name;

            Queue<string> queueOfCostumers = new Queue<string>();

            while((name = Console.ReadLine()) != "End")
            {
                FillAndPaidCostumers(name, queueOfCostumers);

            }

            Console.WriteLine($"{queueOfCostumers.Count} people remaining.");
        }

        private static void FillAndPaidCostumers(string name, Queue<string> queueOfCostumers)
        {
            if (name == "Paid")
            {
                while (queueOfCostumers.Count > 0)
                {
                    Console.WriteLine(queueOfCostumers.Dequeue());

                }
            }
            else
            {

                queueOfCostumers.Enqueue(name);

            }
        }
    }
}
