using System;
using System.Collections.Generic;
using System.Linq;

namespace GaussTrick
{
    class GaussTrick
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int lenght = nums.Count;

            for(int i = 0; i < lenght / 2; i ++)
            {
                nums[i] += nums[lenght - i - 1];
                nums.Remove(nums[lenght - i - 1]);

            }

            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
