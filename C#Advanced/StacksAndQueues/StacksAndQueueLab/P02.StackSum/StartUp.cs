using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.StackSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = input.Split().ToArray();
                string command = cmdArgs[0];

                if (command == "add")
                {
                    AddToStack(stack, cmdArgs);

                }

                else if (command == "remove")
                {
                    RemoveFromStack(stack, cmdArgs);
                }
            }

            PrintStackSum(stack);
        }



        private static void PrintStackSum(Stack<int> stack)
        {
            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }

        private static void RemoveFromStack(Stack<int> stack, string[] cmdArgs)
        {
            int count = int.Parse(cmdArgs[1]);

            if (count <= stack.Count)
            {
                for (int i = 0; i < count; i++)
                {
                    stack.Pop();
                }
            }
        }

        private static void AddToStack(Stack<int> stack, string[] cmdArgs)
        {
            int[] numbersToAdd = cmdArgs.Skip(1)
                .Select(int.Parse)
                .ToArray();

            stack.Push(numbersToAdd[0]);

            stack.Push(numbersToAdd[1]);
        }

    }
}
