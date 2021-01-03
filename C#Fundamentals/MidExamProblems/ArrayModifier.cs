using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ArrayModifier
{
    class ArrayModifier
    { // 05.07.2020
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while(command != "end")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                if(cmd == "swap")
                {
                    int index1 = int.Parse(input[1]);

                    int index2 = int.Parse(input[2]);

                    int temp = list[index1];

                    list[index1] = list[index2];

                    list[index2] = temp;

                }
                else if(cmd == "multiply")
                {
                    int index1 = int.Parse(input[1]);

                    int index2 = int.Parse(input[2]);

                    list[index1] *= list[index2];

                }
                else if (cmd == "decrease")
                {
                    for(int i = 0; i < list.Count; i++)
                    {
                        list[i] -= 1;
                    }
                }

                command = Console.ReadLine();


            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
