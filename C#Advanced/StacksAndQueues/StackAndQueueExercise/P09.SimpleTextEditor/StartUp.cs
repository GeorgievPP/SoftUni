using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P09.SimpleTextEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const string ADD = "1";
            const string REMOVE = "2";
            const string PRINT = "3";
            const string CLEAR = "4";

            StringBuilder sb = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(sb.ToString());

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = input[0];
                if (command == ADD)
                {
                    string argument = input[1];
                    sb.Append(argument);

                    stack.Push(sb.ToString());
                    continue;
                }

                else if (command == REMOVE)
                {

                    int count = int.Parse(input[1]);
                    sb.Remove(sb.Length - count, count);

                    stack.Push(sb.ToString());
                    continue;
                }

                else if (command == PRINT)
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine(sb[index - 1]);
                    continue;
                }
                else if (command == CLEAR)
                {
                    stack.Pop();

                    sb.Clear();
                    sb.Append(stack.Peek());
                    continue;
                }

            }
        }
    }
}
