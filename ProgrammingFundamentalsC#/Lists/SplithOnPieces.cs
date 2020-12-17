using System;
using System.Linq;

namespace SplitOnPieces
{
    class SplithOnPieces
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();

            string[] splitSentance = sentence.Split(" ", 2).ToArray();

            for (int i = 0; i < splitSentance.Length; i++)
            {
                Console.WriteLine($"Element {i} = {splitSentance[i]}");
            }
        }
    }
}
