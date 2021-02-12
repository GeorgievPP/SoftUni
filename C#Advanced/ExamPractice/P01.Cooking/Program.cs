using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.Cooking
{
    class Program
    {
        const int BREAD = 25;
        const int CAKE = 50;
        const int PASTRY = 75;
        const int FRUIT_PIE = 100;
        const int INCREASE = 3;

        static void Main(string[] args)
        {
            int[] liquidInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(liquidInput);

            int[] ingredientInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(ingredientInput);

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;
            bool isColected = false;
           
            while (true)
            {
                if(!queue.Any() || !stack.Any())
                {
                    break;
                }

                int currLiquid = queue.Dequeue();
                int currIngredient = stack.Pop();

                int sum = currLiquid + currIngredient;

                if(sum == BREAD)
                {
                    breadCount++;
                }
                else if(sum == CAKE)
                {
                    cakeCount++;
                }
                else if(sum == PASTRY)
                {
                    pastryCount++;
                }
                else if(sum == FRUIT_PIE)
                {
                    fruitPieCount++;
                }
                else
                {
                    currIngredient += INCREASE;
                    stack.Push(currIngredient);
                }

                if(IsDone(breadCount, cakeCount, pastryCount, fruitPieCount))
                {
                    isColected = true;
                }

            }

            StringBuilder sb = new StringBuilder();

            if (isColected)
            {
                sb.AppendLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                sb.AppendLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            string queueStr = queue.Any() ? String.Join(", ", queue) : "none";
            sb.AppendLine($"Liquids left: {queueStr}");
            string stackStr = stack.Any() ? String.Join(", ", stack) : "none";
            sb.AppendLine($"Ingredients left: {stackStr}");

            sb.AppendLine($"Bread: {breadCount}");
            sb.AppendLine($"Cake: {cakeCount}");
            sb.AppendLine($"Fruit Pie: {fruitPieCount}");
            sb.AppendLine($"Pastry: {pastryCount}");

            Console.WriteLine(sb.ToString().TrimEnd());

        }




        private static bool IsDone(int bread, int cake, int pastry, int fruitPie)
        {
            if(bread > 0 && cake > 0 && pastry > 0 && fruitPie > 0)
            {
                return true;
            }

            return false;
        }
    }
}
