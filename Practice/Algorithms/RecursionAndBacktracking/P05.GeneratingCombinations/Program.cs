using System;
using System.Linq;

namespace P05.GeneratingCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            int count = int.Parse(Console.ReadLine());

            int[] vector = new int[count];

            GetCombinations(set, vector, 0, 0);
        }

        private static void GetCombinations(int[] set, int[] vector, int index, int border)
        {
            if(index == vector.Length)
            {
                Console.WriteLine(String.Join(" ", vector));
            }
            else
            {
                for(int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GetCombinations(set, vector, index + 1, border + 1);
                }
            }
        }
    }
}
