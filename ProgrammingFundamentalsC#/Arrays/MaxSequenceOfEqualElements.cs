using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bestCount = 0;
            int bestIndex = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                int count = 1;
                int el = numbers[i];
                for(int j = i + 1; j < numbers.Length; j++)
                {
                    if(el == numbers[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if(count > bestCount)
                {
                    bestCount = count;
                    bestIndex = i;
                }
           
            }

            for(int i = 0; i < bestCount; i++)
            {
                Console.Write($"{numbers[bestIndex]} ");
            }
        }
    }
}
