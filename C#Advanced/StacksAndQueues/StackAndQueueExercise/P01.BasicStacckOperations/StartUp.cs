using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BasicStackOperation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbersToPush = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            Stack<int> stack = new Stack<int>(numbersToPush);

            RemoveFromStack(s, stack);

            PrintResult(x, stack);
        }

        private static void PrintResult(int x, Stack<int> stack)
        {
            if (stack.Contains(x))
            {

                Console.WriteLine("true");

            }
            else
            {

                Console.WriteLine(stack.Count > 0 ? stack.Min() : 0);

            }
        }

        private static void RemoveFromStack(int s, Stack<int> stack)
        {
            for (int i = 0; i < s; i++)
            {

                stack.Pop();
            }
        }
    }
}
