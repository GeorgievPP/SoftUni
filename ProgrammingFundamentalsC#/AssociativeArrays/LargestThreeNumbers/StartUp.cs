using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.LargestThhreeNumbers
{
    class LargestThreeNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

        // With out "Take(3)"   Termalen operator "(numbers.Count < 3 ? numbers.Count : 3)"

        // for(int i = 0; i < (numbers.Count < 3 ? numbers.Count : 3); i++) 
        // {
        //     Console.WriteLine(numbers[i] + " ");
        // }
    }
}
