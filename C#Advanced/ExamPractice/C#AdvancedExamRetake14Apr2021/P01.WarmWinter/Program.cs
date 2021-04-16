using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputStack = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hatsStack = new Stack<int>(inputStack);

            int[] inputQueue = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> scarfsQueue = new Queue<int>(inputQueue);

            List<int> list = new List<int>();

            while (true)
            {
                if(!hatsStack.Any() || !scarfsQueue.Any())
                {
                    break;
                }

                int hat = hatsStack.Peek();
                int scarf = scarfsQueue.Peek();

                if(hat == scarf)
                {
                    hatsStack.Pop();
                    scarfsQueue.Dequeue();
                    hatsStack.Push(hat + 1);
                }

                else if(hat > scarf)
                {
                    hatsStack.Pop();
                    scarfsQueue.Dequeue();

                    int price = hat + scarf;
                    list.Add(price);
                }

                else if(hat < scarf)
                {
                    hatsStack.Pop();
                }
            }

            int maxSet = 0;

            foreach(var num in list)
            {
                if(num > maxSet)
                {
                    maxSet = num;
                }
            }

            Console.WriteLine($"The most expensive set is: {maxSet}");

            Console.WriteLine(String.Join(' ', list));
        }
    }
}
