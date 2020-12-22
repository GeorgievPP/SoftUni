using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P09.SimpleTextEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            Stack<string> stack = new Stack<string>();

            stack.Push(sb.ToString());

            for(int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = input[0];

                if(command == "1")
                {

                    sb.Append(input[1]);

                    stack.Push(sb.ToString());

                    continue;
                }

                else if(command == "2")
                {

                    int count = int.Parse(input[1]);

                    sb.Remove(sb.Length - count, count);

                    stack.Push(sb.ToString());

                    continue;

                }

                else if(command == "3")
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine(sb[index - 1]);

                    continue;
                }
                else if(command == "4")
                {

                    stack.Pop();

                    sb = new StringBuilder();

                    sb.Append(stack.Peek());

                    continue;
                }

            }
        }
    }
}
