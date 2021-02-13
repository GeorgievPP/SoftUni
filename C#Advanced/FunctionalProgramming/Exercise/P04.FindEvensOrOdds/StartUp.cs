using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startBound = bounds[0];
            int endBound = bounds[1];
            string query = Console.ReadLine();

            Predicate<int> predicate = query == "odd" ? new Predicate<int>((n) => n % 2 != 0)
                                                      : new Predicate<int>((n) => n % 2 == 0);

            List<int> result = new List<int>();

            for (int num = startBound; num <= endBound; num++)
            {
                if (predicate(num))
                {
                    result.Add(num);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
