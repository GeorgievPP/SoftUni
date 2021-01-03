using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Numbers
{
    class Numbers
    { // 05.07.2020
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            double average = list.Average();

            List<int> result = list.OrderByDescending(x => x).Where(x => x > average).Take(5).ToList();

            if(result.Count == 0)
            {
                Console.WriteLine("No");

            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
