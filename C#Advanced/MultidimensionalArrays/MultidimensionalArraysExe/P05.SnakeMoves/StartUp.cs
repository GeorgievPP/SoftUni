using System;
using System.Linq;
using System.Text;

namespace P05.SnakeMoves
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int currentLetter = 0;

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];

            string snakeName = Console.ReadLine();

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snakeName[currentLetter];
                        currentLetter++;
                        currentLetter = CheckCurrentLetter(snakeName, currentLetter);
                    }
                }

                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeName[currentLetter];
                        currentLetter++;
                        currentLetter = CheckCurrentLetter(snakeName, currentLetter);
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static int CheckCurrentLetter(string snakeName, int currentLetter)
        {
            if (currentLetter == snakeName.Length)
            {
                currentLetter = 0;
            }

            return currentLetter;
        }

        public static void PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
