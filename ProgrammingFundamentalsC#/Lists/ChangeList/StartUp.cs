using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while(command != "end")
            {
                string[] input = command.Split();
                
                if(input[0] == "Delete")
                {
                    int removedNumber = int.Parse(input[1]);
                    nums.RemoveAll(x => x == removedNumber);
                }
                else if (input[0] == "Insert")
                {
                    int index = int.Parse(input[2]);
                    int number = int.Parse(input[1]);

                    nums.Insert(index, number);
                }

                command = Console.ReadLine();

            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
