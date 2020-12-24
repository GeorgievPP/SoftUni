using System;
using System.Linq;

namespace P03.PrimaryDiagonal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            matrix = FillMatrix(n);

            int absDifference = 0;

            absDifference = GetDiagonalDifference(matrix);

            Console.WriteLine(absDifference);


        }

        private static int[,] FillMatrix(int n)
        {
            int[,] matrix = new int[n, n];

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

        private static int GetDiagonalDifference(int[,] matrix)
        {

            int sumPrimDiagonal = 0;

            int sumSecDiagonal = 0;

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (row == col)
                    {

                        sumPrimDiagonal += matrix[row, col];

                    }

                    if(col == matrix.GetLength(1) - 1 - row)
                    {

                        sumSecDiagonal += matrix[row, col];

                    }
                }
            }

            sum = Math.Abs(sumPrimDiagonal - sumSecDiagonal);

            return sum;

        }
    }
}
