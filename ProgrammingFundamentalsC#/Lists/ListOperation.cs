using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperation2
{
    class ListOperation2
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while(command != "End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "Add")
                {
                    int addedNumber = int.Parse(input[1]);

                    nums.Add(addedNumber);
                }
                else if (input[0] == "Insert")
                {
                    int index = int.Parse( input[2]);
                    int number = int.Parse(input[1]);
                    if (index >= 0 && index < nums.Count)
                    {
                        nums.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                }
                else if ( input[0] == "Remove")
                {
                    int index = int.Parse(input[1]);

                    if(index >= 0 && index < nums.Count)
                    {
                        nums.RemoveAt(index);
                    } 
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if(input[0] == "Shift")
                {
                    int count = int.Parse(input[2]);

                    count = count % nums.Count;

                    if (input[1] == "left")
                    {
                       for (int i = 0; i < count; i ++)
                        {
                            int firsEl = nums[0];
                            nums.RemoveAt(0);
                            nums.Add(firsEl);
                        }

                    }
                    else if (input[1] == "right")
                    {
                       for(int i = 0; i < count; i ++)
                        {
                            int lastEl = nums[nums.Count - 1];
                            nums.RemoveAt(nums.Count - 1);
                            nums.Insert(0, lastEl);
                        }

                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
