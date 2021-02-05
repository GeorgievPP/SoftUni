using System;

namespace P09.Miner
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int coals = 0;
            string position = "";

            int squareMatrixSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            string[,] matrix = ReadMatrix(squareMatrixSize, squareMatrixSize);
            coals = GetCoalsCount(matrix, coals);

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    bool down = false;

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (currentCommand == "up" && matrix[row, col] == "s" && row - 1 >= 0)
                        {
                            if (matrix[row - 1, col] == "*")
                            {
                                matrix[row, col] = "*";
                                matrix[row - 1, col] = "s";

                            }
                            else if (matrix[row - 1, col] == "c")
                            {
                                matrix[row, col] = "*";
                                matrix[row - 1, col] = "s";
                                coals--;
                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row - 1}, {col})");
                                    return;
                                }

                            }
                            else if (matrix[row - 1, col] == "e")
                            {
                                Console.WriteLine($"Game over! ({row - 1}, {col})");
                                return;

                            }
                            position = $"({row - 1}, {col})";
                            break;
                        }

                        else if (currentCommand == "down" && matrix[row, col] == "s" && row + 1 < matrix.GetLength(0))
                        {
                            if (matrix[row + 1, col] == "*")
                            {
                                matrix[row, col] = "*";
                                matrix[row + 1, col] = "s";
                            }
                            else if (matrix[row + 1, col] == "c")
                            {
                                matrix[row, col] = "*";
                                matrix[row + 1, col] = "s";
                                coals--;
                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row + 1}, {col})");
                                    return;
                                }
                            }
                            else if (matrix[row + 1, col] == "e")
                            {
                                Console.WriteLine($"Game over! ({row + 1}, {col})");
                                return;
                            }
                            down = true;
                            position = $"({row + 1}, {col})";
                            break;
                        }


                        else if (currentCommand == "left" && matrix[row, col] == "s" && col - 1 >= 0)
                        {
                            if (matrix[row, col - 1] == "*")
                            {
                                matrix[row, col] = "*";
                                matrix[row, col - 1] = "s";
                            }
                            else if (matrix[row, col - 1] == "c")
                            {
                                matrix[row, col] = "*";
                                matrix[row, col - 1] = "s";
                                coals--;
                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row}, {col - 1})");
                                    return;
                                }
                            }
                            else if (matrix[row, col - 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({row}, {col - 1})");
                                return;
                            }
                            position = $"({row}, {col - 1})";
                            break;
                        }


                        else if (currentCommand == "right" && matrix[row, col] == "s" && col + 1 < matrix.GetLength(1))
                        {
                            if (matrix[row, col + 1] == "*")
                            {
                                matrix[row, col] = "*";
                                matrix[row, col + 1] = "s";
                            }
                            else if (matrix[row, col + 1] == "c")
                            {
                                matrix[row, col] = "*";
                                matrix[row, col + 1] = "s";
                                coals--;
                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row}, {col + 1})");
                                    return;
                                }
                            }
                            else if (matrix[row, col + 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({row}, {col + 1})");
                                return;
                            }
                            position = $"({row}, {col + 1})";
                            break;
                        }

                    }

                    if (down)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"{coals} coals left. {position}");

        }

        private static int GetCoalsCount(string[,] matrix, int coals)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "c")
                    {
                        coals++;
                    }
                }
            }

            return coals;
        }

        private static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
