using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Func<int[], int> minFunc = (arr) =>
            {

                int minValue = int.MaxValue;

                foreach (var num in arr)
                {

                    if (num < minValue)
                    {

                        minValue = num;

                    }

                }

                return minValue;

            };

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(numbers));
        }
    }
}
