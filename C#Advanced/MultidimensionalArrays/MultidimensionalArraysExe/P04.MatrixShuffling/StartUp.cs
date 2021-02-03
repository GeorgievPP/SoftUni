using System;
using System.Linq;
using System.Text;

namespace P04.MatrixShuffling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const string END_COMMAND = "END";

            int[] matrixInfo = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];
            string[,] matrix = ReadMatrix(rows, cols);

            string input;
            while ((input = Console.ReadLine()) != END_COMMAND)
            {
                if (!ValidateInput(input, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                SwapMatrixElements(matrix, input);

                PrintMatrix(matrix);
            }

        }

        public static void PrintMatrix(string[,] matrix)
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

        private static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

        private static bool ValidateInput(string input, int rows, int cols)
        {
            string[] commands = input.Split();
            if (commands.Length == 5 &&
                commands[0] == "swap" &&
                int.Parse(commands[1]) <= rows &&
                int.Parse(commands[2]) <= cols &&
                int.Parse(commands[3]) <= rows &&
                int.Parse(commands[4]) <= cols)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private static void SwapMatrixElements(string[,] matrix, string input)
        {
            string[] commands = input.Split();

            int rowIndexFirst = int.Parse(commands[1]);
            int colIndexFirst = int.Parse(commands[2]);
            int rowIndexSecond = int.Parse(commands[3]);
            int colIndexSecond = int.Parse(commands[4]);

            string firstElement = matrix[rowIndexFirst, colIndexFirst];
            string secondElement = matrix[rowIndexSecond, colIndexSecond];

            matrix[rowIndexSecond, colIndexSecond] = firstElement;
            matrix[rowIndexFirst, colIndexFirst] = secondElement;
        }



    }
}
