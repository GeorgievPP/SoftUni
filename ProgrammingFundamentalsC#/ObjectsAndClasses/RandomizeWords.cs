using System;

namespace Problem01.RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string[] input = Console.ReadLine().Split(" ");

            for (int i = 0; i < input.Length; i++)
            {
                int index = random.Next(0, input.Length);

                string temVar = input[index];

                input[index] = input[i];

                input[i] = temVar;

            }

            Console.WriteLine(string.Join(Environment.NewLine, input));


        }
    }
}
