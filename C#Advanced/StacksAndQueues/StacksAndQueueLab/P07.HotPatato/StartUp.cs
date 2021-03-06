﻿using System;
using System.Collections.Generic;

namespace P07.HotPatato
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(' ');
            int count = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(children);

            while (queue.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    string currentPlayer = queue.Dequeue();
                    queue.Enqueue(currentPlayer);
                }

                string hotPapatoPlayer = queue.Dequeue();
                Console.WriteLine($"Removed {hotPapatoPlayer}");
            }

            string winner = queue.Dequeue();
            Console.WriteLine($"Last is {winner}");

        }
    }
}
