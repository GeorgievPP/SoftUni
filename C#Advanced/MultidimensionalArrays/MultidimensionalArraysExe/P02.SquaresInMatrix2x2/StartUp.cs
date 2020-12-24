using System;
using System.Linq;

namespace P02._2x2SquaresInMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();

            int rows = matrixInfo[0];

            int cols = matrixInfo[1];

            char[,] matrix = new char[rows, cols];

            FillMatrix(matrix);

            int count = 0;

            PrintCount(rows, cols, matrix, count);

        }

        private static void PrintCount(int rows, int cols, char[,] matrix, int count)
        {
            for (int row = 0; row < rows - 1; row++)
            {

                for (int col = 0; col < cols - 1; col++)
                {

                    char currElement = matrix[row, col];

                    if (currElement == matrix[row, col + 1]
                        && currElement == matrix[row + 1, col]
                        && currElement == matrix[row + 1, col + 1])
                    {

                        count++;

                    }
                }
            }

            Console.WriteLine(count);
        }

        private static void FillMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    matrix[row, col] = currentRow[col];

                }
            }

        }

    }
}
