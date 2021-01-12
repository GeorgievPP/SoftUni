using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {

                int number = int.Parse(Console.ReadLine());

                numbers.Add(number);

            }
                Box<int> box = new Box<int>(numbers);

            int[] indexToSwap = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            box.Swap(box.Values, indexToSwap[0], indexToSwap[1]);

            Console.WriteLine(box);

        }
    }
}
