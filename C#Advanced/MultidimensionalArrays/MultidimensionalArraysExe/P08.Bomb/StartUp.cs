using System;
using System.Linq;
using System.Text;

namespace P08.Bomb2._0
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int cells = 0;
            int sum = 0;

            int squareMatrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(squareMatrixSize, squareMatrixSize);
            string[] cordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cordinates.Length; i++)
            {
                string[] currentCordinates = cordinates[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                int currentRow = int.Parse(currentCordinates[0]);
                int currentCol = int.Parse(currentCordinates[1]);

                if (matrix[currentRow, currentCol] > 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if ((currentRow - 1 == row) && (currentCol - 1 == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col);
                            }
                            if ((currentRow - 1 == row) && (currentCol == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col);
                            }
                            if ((currentRow - 1 == row) && (currentCol + 1 == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col); ;
                            }
                            if ((currentRow == row) && (currentCol - 1 == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col);
                            }
                            if ((currentRow == row) && (currentCol + 1 == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col);
                            }
                            if ((currentRow + 1 == row) && (currentCol - 1 == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col);
                            }
                            if ((currentRow + 1 == row) && (currentCol == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col);
                            }
                            if ((currentRow + 1 == row) && (currentCol + 1 == col) && (matrix[row, col] > 0))
                            {
                                ReduceCurrentElement(matrix, currentRow, currentCol, row, col);
                            }
                        }
                    }

                    matrix[currentRow, currentCol] = 0;
                }
            }

            foreach (var element in matrix)
            {
                if (element > 0)
                {
                    sum += element;
                    cells++;
                }
            }

            PrintResult(matrix, cells, sum);
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
        private static void ReduceCurrentElement(int[,] matrix, int currentRow, int currentCol, int row, int col)
        {
            matrix[row, col] -= matrix[currentRow, currentCol];
        }

        private static void PrintResult(int[,] matrix, int cells, int sum)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Alive cells: ");
            sb.AppendLine($"{cells}");
            sb.Append($"Sum: ");
            sb.AppendLine($"{sum}");
            Console.WriteLine(sb.ToString().TrimEnd());
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append($"{matrix[row, col]} ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

    }
}
