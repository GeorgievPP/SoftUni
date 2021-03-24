using System;
using System.Linq;

namespace P02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            Read(matrix);

            string input;
            while((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                if(coordinates[0] < 0 || coordinates[1] < 0 || coordinates[0] >= matrixSize[0] || coordinates[1] >= matrixSize[1])
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if(row == coordinates[0] || col == coordinates[1])
                        {
                            matrix[row, col] += 1;
                        }
                    }
                }

            }

            Print(matrix);

        }

        private static void Read(int[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }


    }
}
