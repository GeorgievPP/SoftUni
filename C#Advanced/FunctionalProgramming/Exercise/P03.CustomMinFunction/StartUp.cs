using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<int[], int> returnMinNumber = (arrayOfInt) =>
            {
                int minNumber = int.MaxValue;
                foreach (var number in arrayOfInt)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(returnMinNumber(numbers));
        }
    }
}
