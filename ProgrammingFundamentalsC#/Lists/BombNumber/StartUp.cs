using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BombNumbers2
{
    class BombNumber
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int bombNumber = int.Parse(input[0]);

            int power = int.Parse(input[1]);

            int lenght = nums.Count();

            while(true)
            {
                int bombIndex = nums.IndexOf(bombNumber);

                if(bombIndex < 0)
                {
                    break;
                }

                int powerRangeRight = bombIndex + power;

                for(int i = bombIndex; i <= powerRangeRight; i++)
                {
                    if(i > lenght)
                    {
                        break;
                    }
                    else
                    {
                        nums.RemoveAt(bombIndex);
                    }

                    
                }

                int powerRangeLeft = bombIndex - power;

                for(int i = bombIndex - 1; i >= powerRangeLeft; i--)
                {
                    if (i < 0)
                    {
                        break;
                    }
                    else
                    {
                        nums.RemoveAt(i);
                    }

                    
                }

            }

            int sum = nums.Sum();

            Console.WriteLine(sum);


        }
    }
}
