using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.CookingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BREAD = 25;
            const int CAKE = 50;
            const int PASTRY = 75;
            const int FRUIT_PIE = 100;
            const int INCREASER = 3;

            int[] queueInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(queueInput);

            int[] stackInput = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Stack<int> stack = new Stack<int>(stackInput);

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            while (true)
            {
                if (!queue.Any() || !stack.Any())
                {
                    break;
                }

                int currLiquid = queue.Dequeue();
                int currIngredient = stack.Pop();
                int sum = currLiquid + currIngredient;

                if (sum == BREAD)
                {
                    breadCount++;
                }
                else if (sum == CAKE)
                {
                    cakeCount++;
                }
                else if (sum == PASTRY)
                {
                    pastryCount++;
                }
                else if (sum == FRUIT_PIE)
                {
                    fruitPieCount++;
                }
                else
                {
                    stack.Push(currIngredient + INCREASER);
                }
            }

            StringBuilder sb = new StringBuilder();

            if (breadCount > 0 && cakeCount > 0 &&
                pastryCount > 0 && fruitPieCount > 0)
            {
                sb.AppendLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                sb.AppendLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            string liquids = queue.Any() ? String.Join(", ", queue) : "none";
            string ingredients = stack.Any() ? String.Join(", ", stack) : "none";

            sb.AppendLine($"Liquids left: {liquids}")
              .AppendLine($"Ingredients left: {ingredients}")
              .AppendLine($"Bread: {breadCount}")
              .AppendLine($"Cake: {cakeCount}")
              .AppendLine($"Fruit Pie: {fruitPieCount}")
              .AppendLine($"Pastry: {pastryCount}");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
