using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacityOfWagon = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while(command != "end")
            {
                string[] input = command.Split();

                if (input[0] == "Add")
                {
                    int addWagon = int.Parse(input[1]);
                    wagons.Add(addWagon);
                }
                else
                {
                    int passengers = int.Parse(command);
                    for(int i = 0; i < wagons.Count; i ++)
                    {
                        if((passengers + wagons[i]) <= capacityOfWagon)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
