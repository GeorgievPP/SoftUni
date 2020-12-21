using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBotique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothesInBox);

            int sum = 0;

            int count = 0;

            while(stack.Count > 0)
            {
                int num = stack.Pop();

                sum += num;

                if(sum > capacity)
                {
                    stack.Push(num);

                    count++;

                    sum = 0;

                }

                if(stack.Count == 0)
                {
                    count++;

                    break;
                }


            }

            Console.WriteLine(count);
        }
    }
}
