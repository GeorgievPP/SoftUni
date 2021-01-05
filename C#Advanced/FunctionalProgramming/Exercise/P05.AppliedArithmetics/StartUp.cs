using System;
using System.Linq;

namespace P05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Action<int[]> print = (arr) =>
            {

                Console.WriteLine(String.Join(' ', arr));

            };

            string input;

            while ((input = Console.ReadLine()) != "end")
            {

                if (input == "print")
                {

                    print(numbers);

                }

                else
                {

                    Func<int[], int[]> processor = GetProcessor(input);

                    numbers = processor(numbers);

                }

            }

        }

        static Func<int[], int[]> GetProcessor(string input)
        {

            Func<int[], int[]> processor = null;

            if (input == "add")
            {

                processor = new Func<int[], int[]>((arr) =>
                {

                    for (int i = 0; i < arr.Length; i++)
                    {

                        arr[i]++;

                    }

                    return arr;

                });

            }

            else if (input == "multiply")
            {

                processor = new Func<int[], int[]>((arr) =>
                {

                    for (int i = 0; i < arr.Length; i++)
                    {

                        arr[i] = arr[i] * 2;

                    }

                    return arr;

                });

            }

            else if (input == "subtract")
            {

                processor = new Func<int[], int[]>((arr) =>
                {

                    for (int i = 0; i < arr.Length; i++)
                    {

                        arr[i]--;

                    }

                    return arr;

                });

            }

            return processor;
        }
    }
}
