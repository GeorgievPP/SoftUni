using System;
using System.Linq;
using System.Text;

namespace P03.MaximalSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int targetRow = -1;
            int targetCol = -1;
            int maxSum = int.MinValue;

            int[] matrixInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];
            int[,] matrix = ReadMatrix(rows, cols);

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = GetSumOf3X3Matrix(matrix, row, col);

                    if (currentSum > maxSum)
                    {
                        targetRow = row;
                        targetCol = col;
                        maxSum = currentSum;
                    }
                }
            }

            PrintMaxSumMatrix(maxSum, matrix, targetRow, targetCol);
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        private static int GetSumOf3X3Matrix(int[,] matrix, int row, int col)
        {
            int firstRowSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
            int secondRowSum = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
            int thirdRowSum = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
            int sum = firstRowSum + secondRowSum + thirdRowSum;

            return sum;
        }

        private static void PrintMaxSumMatrix(int maxSum, int[,] matrix, int targetRow, int targetCol)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Sum = {maxSum}");

            for (int row = targetRow; row <= targetRow + 2; row++)
            {
                for (int col = targetCol; col <= targetCol + 2; col++)
                {
                    sb.Append($"{matrix[row, col]} ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
