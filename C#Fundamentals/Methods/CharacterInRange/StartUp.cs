using System;

namespace Proble03.CharacterInRange
{
    class CharacterInRange
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());

            char endChar = char.Parse(Console.ReadLine());

            int startIndex = Math.Min(startChar, endChar);

            int endIndex = Math.Max(startChar, endChar);

            ReturnCharacters(startIndex, endIndex);
        }

        private static void ReturnCharacters(int startIndex, int endIndex)
        {
            for (int i = startIndex + 1; i < endIndex; i++)
            {
                char currentCh = (char)(i);

                Console.Write($"{currentCh} ");
            }
        }
    }
}
