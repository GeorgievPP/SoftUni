using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace P03.LastStop
{
    class LastStop
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while(command != "END")
            {
                string[] input = command.Split().ToArray();

                string word = input[0];

                if(word == "Change")
                {
                    int num = int.Parse(input[1]);

                    int newNum = int.Parse(input[2]);

                    if ( nums.Contains(num))
                    {
                        int index = nums.IndexOf(num);
                        nums.RemoveAt(index);
                        if (index == nums.Count)
                        {
                            nums.Add(newNum);
                        }
                        else
                        {
                            nums.Insert(index, newNum);

                        }
                    }
                    
                }
                else if (word == "Hide")
                {
                    int num = int.Parse(input[1]);

                    if(nums.Contains(num))
                    {
                        
                        nums.Remove(num);

                    }

                }
                else if(word == "Switch")
                {
                    int num1 = int.Parse(input[1]);
                    int num2 = int.Parse(input[2]);

                    if (nums.Contains(num1) && nums.Contains(num2))
                    {
                        int index1 = nums.IndexOf(num1);
                        int index2 = nums.IndexOf(num2);

                        int temp = nums[index1];

                        nums[index1] = nums[index2];

                        nums[index2] = temp;
                    }

                }
                else if (word == "Insert")
                {
                    int index = int.Parse(input[1]);
                    int num = int.Parse(input[2]);

                    if ((index + 1) > 0 && (index + 1) < nums.Count)
                    {
                        
                        nums.Insert(index + 1, num);
                    }
                    else if( index +1 == nums.Count)
                    {
                        nums.Add(num);
                    }
                }
                else if (word == "Reverse")
                {
                    nums.Reverse();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
