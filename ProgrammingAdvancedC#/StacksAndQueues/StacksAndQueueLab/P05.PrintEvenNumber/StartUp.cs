using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.PrintEvenNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> inputQueue = new Queue<int>(numbers);

            Queue<int> evenNumbersQueue = new Queue<int>();

            FillEvenNumbersQueue(numbers, inputQueue, evenNumbersQueue);

            PrintEvenQueue(evenNumbersQueue);
        }

        private static void PrintEvenQueue(Queue<int> evenNumbersQueue)
        {
            while (evenNumbersQueue.Count > 0)
            {

                if (evenNumbersQueue.Count == 1)
                {
                    Console.Write(evenNumbersQueue.Dequeue());
                }
                else
                {
                    Console.Write($"{evenNumbersQueue.Dequeue()}, ");
                }


            }
        }

        public static void FillEvenNumbersQueue(int[] numbers, Queue<int> inputQueue, Queue<int> evenNumbersQueue)
        {
            for (int i = 0; i < numbers.Length; i++)
            {

                int n = inputQueue.Dequeue();

                if (n % 2 == 0)
                {
                    evenNumbersQueue.Enqueue(n);
                }

            }
        }
    }
}
