using System;
using System.Linq;

namespace MagicSum
{
    class MagicSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < arr.Length - 1; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    int sum = arr[i] + arr[j];
                    if (sum == n)
                    {
                        Console.WriteLine($"{arr[i]} {arr[j]}");
                    }
                }
                
            }
        }
    }
}
