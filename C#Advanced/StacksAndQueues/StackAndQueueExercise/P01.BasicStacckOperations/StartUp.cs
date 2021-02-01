using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

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

            int numbersToRemoveCount = input[1];
            int elementToFound = input[2];

            int[] numbersToPush = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbersToPush);

            RemoveFromStack(numbersToRemoveCount, stack);

            SerachingForElement(elementToFound, stack);


        }

        private static void SerachingForElement(int elementToFound, Stack<int> stack)
        {
            StringBuilder sb = new StringBuilder();
            if (stack.Contains(elementToFound))
            {
                sb.Append("true");
            }

            else
            {
                int smallestNumber = stack.Count > 0 ? stack.Min() : 0;
                sb.Append(smallestNumber);
            }

            Console.WriteLine(sb.ToString());
        }

        private static void RemoveFromStack(int count, Stack<int> stack)
        {
            for (int i = 0; i < count; i++)
            {
                stack.Pop();
            }
        }
    }
}
