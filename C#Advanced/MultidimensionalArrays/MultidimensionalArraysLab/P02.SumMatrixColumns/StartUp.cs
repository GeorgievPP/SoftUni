using System;
using System.Linq;

namespace P02.SumMatrixColumns
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = ReadMatrix(sizes[0], sizes[1]);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {

                int sum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    sum += matrix[row, col];

                }

                Console.WriteLine(sum);
            }
        }

        public static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
