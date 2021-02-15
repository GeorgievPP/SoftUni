using System;
using System.Linq;

namespace P10.RadioactiveMutantVampireBunnies2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentRow = 0;
            int currentCol = 0;

            int[] matrixSizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[matrixSizes[0], matrixSizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string commands = Console.ReadLine().ToLower();

            foreach (char command in commands)
            {
                if (command == 'u')
                {
                    Up(matrix, currentRow, currentCol);
                    currentRow--;

                    if (Populate(ref matrix, currentRow, currentCol))
                    {
                        Die(matrix, currentRow, currentCol);
                    }

                }

                else if (command == 'd')
                {
                    Down(matrix, currentRow, currentCol);
                    currentRow++;

                    if (Populate(ref matrix, currentRow, currentCol))
                    {
                        Die(matrix, currentRow, currentCol);
                    }

                }

                else if (command == 'l')
                {
                    Left(matrix, currentRow, currentCol);
                    currentCol--;

                    if (Populate(ref matrix, currentRow, currentCol))
                    {
                        Die(matrix, currentRow, currentCol);
                    }

                }

                else if (command == 'r')
                {
                    Right(matrix, currentRow, currentCol);
                    currentCol++;

                    if (Populate(ref matrix, currentRow, currentCol))
                    {
                        Die(matrix, currentRow, currentCol);
                    }

                }

            }

        }

        private static void Up(char[,] matrix, int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = '.';

            if (currentRow == 0)
            {
                Populate(ref matrix, currentRow, currentCol);
                Win(matrix, currentRow, currentCol);
            }

            else
            {
                if (matrix[currentRow - 1, currentCol] == 'B')
                {
                    Populate(ref matrix, currentRow, currentCol);
                    Die(matrix, currentRow - 1, currentCol);
                }
                else
                {
                    matrix[currentRow - 1, currentCol] = 'P';
                }
            }
        }

        private static void Down(char[,] matrix, int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = '.';

            if (currentRow == matrix.GetLength(0) - 1)
            {
                Populate(ref matrix, currentRow, currentCol);
                Win(matrix, currentRow, currentCol);
            }

            else
            {
                if (matrix[currentRow + 1, currentCol] == 'B')
                {
                    Populate(ref matrix, currentRow, currentCol);
                    Die(matrix, currentRow + 1, currentCol);
                }
                else
                {
                    matrix[currentRow + 1, currentCol] = 'P';
                }
            }
        }

        private static void Left(char[,] matrix, int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = '.';

            if (currentCol == 0)
            {
                Populate(ref matrix, currentRow, currentCol);
                Win(matrix, currentRow, currentCol);
            }

            else
            {
                if (matrix[currentRow, currentCol - 1] == 'B')
                {
                    Populate(ref matrix, currentRow, currentCol);
                    Die(matrix, currentRow, currentCol - 1);
                }
                else
                {
                    matrix[currentRow, currentCol] = 'P';
                }
            }
        }

        private static void Right(char[,] matix, int currentRow, int currentCol)
        {
            matix[currentRow, currentCol] = '.';

            if (currentCol == matix.GetLength(1) - 1)
            {
                Populate(ref matix, currentRow, currentCol);
                Win(matix, currentRow, currentCol);
            }

            else
            {
                if (matix[currentRow, currentCol + 1] == 'B')
                {
                    Populate(ref matix, currentRow, currentCol);
                    Die(matix, currentRow, currentCol + 1);
                }
                else
                {
                    matix[currentRow, currentCol + 1] = 'P';
                }
            }
        }

        private static bool Populate(ref char[,] matrix, int currentRow, int currentCol)
        {
            bool isDead = true;
            char[,] result = new char[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy(matrix, result, matrix.Length);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row > 0 && matrix[row, col].Equals('B'))
                    {
                        result[row - 1, col] = 'B';
                    }

                    if (row < matrix.GetLength(0) - 1 && matrix[row, col].Equals('B'))
                    {
                        result[row + 1, col] = 'B';
                    }

                    if (col > 0 && matrix[row, col].Equals('B'))
                    {
                        result[row, col - 1] = 'B';
                    }

                    if (col < matrix.GetLength(1) - 1 && matrix[row, col].Equals('B'))
                    {
                        result[row, col + 1] = 'B';
                    }
                }
            }

            isDead = CheckIfPlayerIsAlive(result, isDead);
            matrix = result;

            return isDead;
        }

        private static bool CheckIfPlayerIsAlive(char[,] result, bool isDead)
        {
            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    if (result[row, col] == 'P')
                    {
                        isDead = false;
                    }
                }
            }

            return isDead;
        }

        private static void Die(char[,] matrix, int currentRow, int currentCol)
        {
            RemoveP(matrix);
            PrintMatrix(matrix);
            Console.WriteLine($"dead: {currentRow} {currentCol}");
            Environment.Exit(0);
        }

        private static void Win(char[,] matrix, int currentRow, int currentCol)
        {
            PrintMatrix(matrix);
            Console.WriteLine($"won: {currentRow} {currentCol}");
            Environment.Exit(0);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void RemoveP(char[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 'P')
                    {
                        matrix[row, col] = '.';
                    }
                }
            }
        }
    }
}
