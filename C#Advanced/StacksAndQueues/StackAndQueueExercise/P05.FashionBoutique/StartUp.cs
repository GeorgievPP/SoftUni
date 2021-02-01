using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.FashionBotique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int clothesSum = 0;
            int packagesCount = 0;

            int[] clothesInBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int packageCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothesInBox);

            while (stack.Count > 0)
            {
                int currentClothesSum = stack.Pop();
                clothesSum += currentClothesSum;

                if (clothesSum > packageCapacity)
                {
                    stack.Push(currentClothesSum);
                    packagesCount++;
                    clothesSum = 0;
                }

                if (stack.Count == 0)
                {
                    packagesCount++;
                    break;
                }
            }

            Console.WriteLine(packagesCount);
        }
    }
}
