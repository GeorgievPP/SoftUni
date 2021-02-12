using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.Bombs2._0
{
    class Program
    {
        const int DATURA_BOOMB = 40;
        const int CHERRY_BOOMB = 60;
        const int SMOKE_DECOY_BOOMB = 120;
        const int DECREASE = 5;


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
            bool isDone = false;

            while (true)
            {
                if (!queue.Any() || !stack.Any())
                {
                    break;
                }

                int bombEffect = queue.Peek();
                int bombCasing = stack.Pop();
                int sum = bombEffect + bombCasing;

                if (sum == DATURA_BOOMB)
                {
                    daturaCount++;
                    queue.Dequeue();
                }
                else if (sum == CHERRY_BOOMB)
                {
                    cherryCount++;
                    queue.Dequeue();
                }
                else if (sum == SMOKE_DECOY_BOOMB)
                {
                    smokeCount++;
                    queue.Dequeue();
                }
                else
                {
                    bombCasing -= DECREASE;
                    stack.Push(bombCasing);
                }

                if (IsCompleate(daturaCount, cherryCount, smokeCount))
                {
                    isDone = true;
                    break;
                }

            }

            StringBuilder sb = new StringBuilder();

            if (isDone)
            {
                sb.AppendLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                sb.AppendLine($"You don't have enough materials to fill the bomb pouch.");
            }

            string bombEffects = queue.Any() ? String.Join(", ", queue) : "empty";
            string bombCasings = stack.Any() ? String.Join(", ", stack) : "empty";

            sb.AppendLine($"Bomb Effects: {bombEffects}")
              .AppendLine($"Bomb Casings: {bombCasings}")
              .AppendLine($"Cherry Bombs: {cherryCount}")
              .AppendLine($"Datura Bombs: {daturaCount}")
              .AppendLine($"Smoke Decoy Bombs: {smokeCount}");

            Console.WriteLine(sb.ToString().TrimEnd());

        }

        private static bool IsCompleate(int datura, int cherry, int smoke)
        {
            if (datura >= 3 && cherry >= 3 && smoke >= 3)
            {
                return true;
            }

            return false;
        }
    }
}
