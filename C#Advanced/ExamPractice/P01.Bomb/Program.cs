using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] queueInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(queueInput);

            int[] stackInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(stackInput);

            int daturaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;
            bool collectAll = false;

            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (true)
            {
                if(!queue.Any() || !stack.Any())
                {
                    break;
                }

                int bombEffect = queue.Peek();
                int bombCasing = stack.Pop();

                int sum = bombEffect + bombCasing;

                if(sum == 40)
                {
                    queue.Dequeue();
                    daturaCount++;
                }
                else if (sum == 60)
                {
                    queue.Dequeue();
                    cherryCount++;
                }
                else if ( sum == 120)
                {
                    queue.Dequeue();
                    smokeCount++;
                }
                else
                {
                    stack.Push(bombCasing - 5);
                }

                if(daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
                {
                    collectAll = true;
                    break;
                }

            }

            StringBuilder sb = new StringBuilder();

            if (collectAll)
            {
                sb.AppendLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                sb.AppendLine("You don't have enough materials to fill the bomb pouch.");
            }

            string str = queue.Any() ? String.Join(", ", queue) : "empty";
            sb.AppendLine($"Bomb Effects: {str}");
            string str2 = stack.Any() ? String.Join(", ", stack) : "empty";
            sb.AppendLine($"Bomb Casings: {str2}");

            dict.Add("Cherry Bombs", cherryCount);
            dict.Add("Datura Bombs", daturaCount);
            dict.Add("Smoke Decoy Bombs", smokeCount);

            foreach(var kvp in dict.OrderBy(k => k.Key))
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
