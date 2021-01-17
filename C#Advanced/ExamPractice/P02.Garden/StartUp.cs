using System;
using System.Linq;
using System.Text;

namespace P02.Garden
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            if (rows == cols)
            {

                int[,] matrix = new int[rows, cols];

                FillGarden(matrix);

                string input;

                while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
                {
                    int[] plantFlowerPos = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray();

                    int plantFlowerPosRow = plantFlowerPos[0];
                    int plantFlowerPosCol = plantFlowerPos[1];

                    if (plantFlowerPosRow < 0 || plantFlowerPosRow >= matrix.GetLength(0)
                        || plantFlowerPosCol < 0 || plantFlowerPosCol >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid coordinates.");
                        continue;
                    }

                    PlantingGarden(matrix, plantFlowerPos);
                }

                PrintGarden(matrix);
            }

        }

        private static void PlantingGarden(int[,] matrix, int[] input)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == input[0] || col == input[1])
                    {

                        matrix[row, col] += 1;
                    }

                }

            }

        }

        public static void FillGarden(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

        }

        public static void PrintGarden(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);

                    if (col != matrix.GetLength(1) - 1)
                    {
                        sb.Append(" ");

                    }
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
