using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.MaximumAndMinimumElement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const string PUSH = "1";
            const string DELETE = "2";
            const string MAX = "3";
            const string MIN = "4";

            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == PUSH)
                {
                    int elementToPush = int.Parse(cmdArgs[1]);
                    stack.Push(elementToPush);
                }

                else if (cmdType == DELETE)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }

                else if (cmdType == MAX)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }

                else if (cmdType == MIN)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }

            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
