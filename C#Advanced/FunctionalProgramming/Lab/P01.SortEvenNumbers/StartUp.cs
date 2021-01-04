using System;
using System.Linq;

namespace P01.SortEvenNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select((numbers) =>
                {

                    return int.Parse(numbers);

                })
                .Where(x => x % 2 == 0)
                .OrderBy((int x) =>
                {

                    return x;

                })
                .ToArray();

            Console.WriteLine(String.Join(", ", numbers));

        }
    }
}
