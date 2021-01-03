using System;

namespace P06.ReplaceRepeatingChar
{
    class ReplaceRepeatingChar
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for(int i = 0; i < input.Length; i++)
            {
                char currentCh = input[i];

                int subsequenceLength = 0;

                for(int j = i + 1; j < input.Length; j++)
                {
                    char nextCh = input[j];

                    if(currentCh == nextCh)
                    {
                        subsequenceLength++;

                    }
                    else
                    {
                        break;

                    }
                }

                input = input.Remove(i + 1, subsequenceLength);

            }

            Console.WriteLine(input);

        }
    }
}
