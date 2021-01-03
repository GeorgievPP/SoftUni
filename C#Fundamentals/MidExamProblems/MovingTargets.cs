using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MovingTarget
{
    class MovingTargets
    { // 07 April 2020
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while(command !="End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string cmd = input[0];

                int index = int.Parse(input[1]);

                if((cmd == "Shoot") && (index >=0 && index < list.Count))
                {
                    int power = int.Parse(input[2]);

                    list[index] -= power;
                    if(list[index] <= 0)
                    {
                        list.RemoveAt(index);

                    }
                }
                else if(cmd =="Add")
                {
                    if (index >= 0 && index < list.Count)
                    {
                        int value = int.Parse(input[2]);

                        list.Insert(index, value);

                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if(cmd == "Strike")
                {
                    int radius = int.Parse(input[2]);
                    if((index >= 0 && index < list.Count) && (index - radius >= 0 && index + radius < list.Count))
                    {
                        for(int i = index - radius; i <= index + radius; i++)
                        {
                            list.RemoveAt(index - radius);

                        }
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");

                    }
                }

                command = Console.ReadLine();

            }

            Console.WriteLine(string.Join('|', list));
        }
    }
}
