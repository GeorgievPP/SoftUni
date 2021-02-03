using System;
using System.Linq;
using System.Text;

namespace P05._5._SquareWithMaximumSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int maxRow = 0;
            int maxCol = 0;
            int maxSum = int.MinValue;
            StringBuilder sb = new StringBuilder();

            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = ReadMatrix(rows, cols);

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row + 1, col]
                        + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = sum;
                    }
                }
            }

            sb.AppendLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}")
              .AppendLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}")
              .AppendLine($"{maxSum}");

            Console.WriteLine(sb.ToString());
        }

        public static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
