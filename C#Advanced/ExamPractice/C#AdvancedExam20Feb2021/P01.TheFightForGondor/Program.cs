using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToList();

            Stack<int> warriorOrcs = new Stack<int>();

            for(int i = 1; i<= numberOfWaves; i++)
            {
                warriorOrcs = new Stack<int>(Console.ReadLine()
                    .Split(' ').Select(int.Parse).ToArray());

                if(i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                }

                while(warriorOrcs.Any() && plates.Any())
                {
                    int orc = warriorOrcs.Peek();
                    int plate = plates[0];

                    if(orc == plate)
                    {
                        warriorOrcs.Pop();
                        plates.Remove(plate);
                    }
                    else if(orc > plate)
                    {
                        warriorOrcs.Push(warriorOrcs.Pop() - plate);
                        plates.Remove(plate);
                    }
                    else if(orc < plate)
                    {
                        plates[0] -= orc;
                        warriorOrcs.Pop();
                    }
                }

                if(plates.Count == 0)
                {
                    break;
                }
            }

            if (plates.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", warriorOrcs)}");
            }
        }
    }
}
