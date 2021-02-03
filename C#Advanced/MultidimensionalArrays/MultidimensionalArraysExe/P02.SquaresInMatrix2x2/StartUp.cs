using System;
using System.Linq;

namespace P02._2x2SquaresInMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = 0;
            int[] matrixInfo = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];
            char[,] matrix = ReadMatrix(rows, cols);

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char currentElement = matrix[row, col];

                    if (IsEqual(matrix, row, col, currentElement))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static bool IsEqual(char[,] matrix, int row, int col, char currentElement)
        {
            bool firstCheck = currentElement.Equals(matrix[row, col + 1]);
            bool secondCheck = currentElement.Equals(matrix[row + 1, col]);
            bool thirdCheck = currentElement.Equals(matrix[row + 1, col + 1]);
            bool equal = firstCheck && secondCheck && thirdCheck;

            return equal;
        }


        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
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

            return matrix;
        }

    }
}
