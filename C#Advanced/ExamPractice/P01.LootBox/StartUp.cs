using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.LootBox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputQueue = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(inputQueue);

            int[] inputStack = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(inputStack);

            int totalLoot = 0;

            while (true)
            {
                if (!queue.Any() || !stack.Any())
                {
                    break;
                }

                int firstLootCurrNumber = queue.Peek();
                int secondLootCurrNumber = stack.Pop();
                int sum = firstLootCurrNumber + secondLootCurrNumber;

                if (sum % 2 == 0)
                {
                    totalLoot += sum;
                    queue.Dequeue();
                    continue;
                }

                else
                {
                    queue.Enqueue(secondLootCurrNumber);
                }
            }

            if (!queue.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if( totalLoot >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {totalLoot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {totalLoot}");
            }
        }
    }
}
