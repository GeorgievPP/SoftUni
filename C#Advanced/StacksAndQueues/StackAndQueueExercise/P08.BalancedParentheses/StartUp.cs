using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.BalancedParentheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<char> queue = new Queue<char>(input);

            int count = 0;
            bool isBalanced = true;

            if (queue.Count % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            while (queue.Any())
            {
                char firstChar = queue.Dequeue();
                char secondChar = queue.Peek();

                if (firstChar == '{')
                {
                    if (secondChar == '}')
                    {
                        queue.Dequeue();
                        count = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(firstChar);
                    }
                }

                else if (firstChar == '[')
                {
                    if (secondChar == ']')
                    {
                        queue.Dequeue();
                        count = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(firstChar);
                    }
                }

                else if (firstChar == '(')
                {
                    if (secondChar == ')')
                    {
                        queue.Dequeue();
                        count = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(firstChar);
                    }
                }

                else
                {
                    queue.Enqueue(firstChar);
                }

                count++;

                if (count == queue.Count)
                {
                    isBalanced = false;
                    break;
                }

            }

            string answer = isBalanced ? "YES" : "NO";
            Console.WriteLine(answer);
        }
    }
}
