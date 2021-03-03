using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Console.WriteLine(GetSum(array, 0));

        }

        private static int GetSum(int[] array, int index)
        {
            if(index >= array.Length)
            {
                return 0;
            }

            return array[index] + GetSum(array, index + 1);
        }
    }
}
