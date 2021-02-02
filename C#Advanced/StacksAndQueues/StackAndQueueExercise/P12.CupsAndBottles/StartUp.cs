using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P12.CupsAndBottles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int wastetWater = 0;
            bool noCups = false;
            StringBuilder sb = new StringBuilder();

            int[] cups = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueCups = new Queue<int>(cups);

            int[] bottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stakcBottles = new Stack<int>(bottles);

            while (true)
            {
                int currentCup = queueCups.Peek();
                int currentBottle = stakcBottles.Pop();

                if (currentBottle >= currentCup)
                {
                    queueCups.Dequeue();
                    wastetWater += (currentBottle - currentCup);
                }
                else
                {
                    currentCup -= currentBottle;
                    while (currentCup > 0)
                    {
                        currentBottle = stakcBottles.Pop();
                        if (currentCup > currentBottle)
                        {
                            currentCup -= currentBottle;
                        }
                        else
                        {
                            queueCups.Dequeue();
                            wastetWater += (currentBottle - currentCup);
                            currentCup -= currentBottle;
                        }
                    }
                }

                if (!queueCups.Any())
                {
                    noCups = true;
                    break;
                }
                if (!stakcBottles.Any())
                {
                    break;
                }
            }

            if (noCups)
            {
                sb.AppendLine($"Bottles: {String.Join(' ', stakcBottles)}")
                  .AppendLine($"Wasted litters of water: {wastetWater}");
            }
            else
            {
                sb.AppendLine($"Cups: {String.Join(' ', queueCups)}")
                  .AppendLine($"Wasted litters of water: {wastetWater}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
