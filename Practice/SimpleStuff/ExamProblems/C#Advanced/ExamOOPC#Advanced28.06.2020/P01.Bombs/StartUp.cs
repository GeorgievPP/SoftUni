using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam28June2020
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] queueInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(queueInput);

            int[] stackInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(stackInput);

            int darutaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;
            bool filed = false;

            //int sum = 0;

            while(queue.Any() && stack.Any())
            {
                int effect = queue.Peek();
                int casing = stack.Pop();

                int sum = effect + casing;
                
                if(sum == 40)
                {
                    queue.Dequeue();
                    darutaCount++;
                }
                else if(sum == 60)
                {
                    queue.Dequeue();
                    cherryCount++;
                }
                else if(sum == 120)
                {
                    queue.Dequeue();
                    smokeCount++;
                }
                else
                {
                    casing -= 5;
                    stack.Push(casing);
                }

                if(darutaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
                {
                    filed = true;
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();

            if (filed)
            {
                sb.AppendLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                sb.AppendLine("You don't have enough materials to fill the bomb pouch.");
            }

            string bombEffects = queue.Any() ? String.Join(", ", queue) : "empty";
            string bombCasings = stack.Any() ? String.Join(", ", stack) : "empty";

            sb.AppendLine($"Bomb Effects: {bombEffects}");
            sb.AppendLine($"Bomb Casings: {bombCasings}");
            sb.AppendLine($"Cherry Bombs: {cherryCount}");
            sb.AppendLine($"Daruta Bombs: {darutaCount}");
            sb.AppendLine($"Smoke Decoy Bombs: {smokeCount}");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
