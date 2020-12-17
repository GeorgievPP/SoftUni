using System;

namespace Problem02.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstString = input[0];

            string secondString = input[1];

            int lenght = Math.Min(firstString.Length, secondString.Length);

            long sum = 0;

            sum = ReturningMultipliedSum(firstString, secondString, lenght, sum);

            if (firstString.Length > lenght)
            {
                sum = AddSum(firstString, lenght, sum);
            }

            else if (secondString.Length > lenght)
            {
                sum = AddSum(secondString, lenght, sum);
            }

            Console.WriteLine(sum);
        }

        private static long AddSum(string text, int lenght, long sum)
        {
            for (int j = lenght; j < text.Length; j++)
            {
                int num3 = (char)(text[j]);

                sum += num3;
            }

            return sum;
        }

        private static long ReturningMultipliedSum(string firstString, string secondString, int lenght, long sum)
        {
            for (int i = 0; i < lenght; i++)
            {
                int num1 = (char)(firstString[i]);

                int num2 = (char)(secondString[i]);

                sum += (num1 * num2);
            }

            return sum;
        }
    }
}
