using System;

namespace ZigZagArrays
{
    class ZigZagArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arrZig = new string[n];
            string[] arrZag = new string[n];

            for(int i = 0; i < n; i++)
            {
                string[] nums = Console.ReadLine().Split();

                if (i % 2 == 0)
                {
                    arrZig[i] = nums[0];
                    arrZag[i] = nums[1];
                }
                else
                {
                    arrZig[i] = nums[1];
                    arrZag[i] = nums[0];
                }
            }

            Console.WriteLine(string.Join(" ", arrZig));
            Console.WriteLine(string.Join(" ", arrZag));
        }
    }
}
