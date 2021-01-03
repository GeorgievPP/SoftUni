using System;
using System.Linq;

namespace P08.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double sum = 0;

            for (int i = 0; i < words.Length; i++)
            {
                double tempSum = 0;

                string currentWord = words[i];

                char firstLetter = currentWord[0];

                char lastLetter = currentWord[currentWord.Length - 1];

                char[] numberAsCharArray = currentWord
                    .Skip(1)
                    .Take(currentWord.Length - 2)
                    .ToArray();

                string numberAsString = string.Join("", numberAsCharArray);

                double number = double.Parse(numberAsString);

                tempSum += number;

                int firstLetterPosition = GetAlphgabeticalPositionByLetter(firstLetter);

                int lastLetterPosition = GetAlphgabeticalPositionByLetter(lastLetter);

                if (char.IsUpper(firstLetter) && firstLetterPosition > 0)
                {
                    tempSum = number / firstLetterPosition;

                }
                else if (char.IsLower(firstLetter) && firstLetterPosition > 0)
                {
                    tempSum = number * firstLetterPosition;
                }

                if (char.IsUpper(lastLetter) && lastLetter > 0)
                {
                    tempSum -= lastLetterPosition;

                }
                else if (char.IsLower(lastLetter) && lastLetterPosition > 0)
                {
                    tempSum += lastLetterPosition;

                }

                sum += tempSum;

            }

            Console.WriteLine($"{sum:f2}");
        }

        private static int GetAlphgabeticalPositionByLetter(char letter)
        {
            int position = -1;

            if (char.IsLetter(letter))
            {
                if (char.IsUpper(letter))
                {
                    position = letter - 64;

                }
                else
                {
                    position = letter - 96;

                }
            }

            return position;
        }
    }
}
