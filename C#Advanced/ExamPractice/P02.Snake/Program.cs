using System;

namespace P02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = -1;
            int playerCol = -1;

            int firstPortalBRow = -1;
            int firstPortalBCol = -1;

            int secondPortalBRow = -1;
            int secondPortalBCol = -1;
            int count = 0;
            bool won = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();


                for (int col = 0; col < currentRow.Length; col++)
                {

                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (currentRow[col] == 'B' && count == 0)
                    {
                        firstPortalBRow = row;
                        firstPortalBCol = col;
                        count++;
                    }

                    else if (currentRow[col] == 'B' && count == 1)
                    {
                        secondPortalBRow = row;
                        secondPortalBCol = col;
                    }
                }



            }

            int foodCount = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;

                        if (matrix[playerRow, playerCol] == '*')
                        {
                            foodCount++;
                            matrix[playerRow, playerCol + 1] = '.';
                            matrix[playerRow, playerCol] = 'S';

                        }

                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (matrix[playerRow, playerCol] == matrix[firstPortalBRow, firstPortalBCol])
                            {
                                matrix[playerRow, playerCol + 1] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = secondPortalBRow;
                                playerCol = secondPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }

                            else if (matrix[playerRow, playerCol] == matrix[secondPortalBRow, secondPortalBCol])
                            {
                                matrix[playerRow, playerCol + 1] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = firstPortalBRow;
                                playerCol = firstPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = 'S';
                            matrix[playerRow, playerCol + 1] = '.';
                        }


                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }

                else if (command == "right")
                {
                    if (playerCol + 1 < size)
                    {
                        playerCol++;

                        if (matrix[playerRow, playerCol] == '*')
                        {
                            foodCount++;
                            matrix[playerRow, playerCol - 1] = '.';
                            matrix[playerRow, playerCol] = 'S';

                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (matrix[playerRow, playerCol] == matrix[firstPortalBRow, firstPortalBCol])
                            {
                                matrix[playerRow, playerCol - 1] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = secondPortalBRow;
                                playerCol = secondPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }
                            else if (matrix[playerRow, playerCol] == matrix[secondPortalBRow, secondPortalBCol])
                            {
                                matrix[playerRow, playerCol - 1] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = firstPortalBRow;
                                playerCol = firstPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = 'S';
                            matrix[playerRow, playerCol - 1] = '.';
                        }
                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }

                else if (command == "down")
                {
                    if (playerRow + 1 < size)
                    {
                        playerRow++;

                        if (matrix[playerRow, playerCol] == '*')
                        {
                            foodCount++;
                            matrix[playerRow - 1, playerCol] = '.';
                            matrix[playerRow, playerCol] = 'S';

                        }

                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (matrix[playerRow, playerCol] == matrix[firstPortalBRow, firstPortalBCol])
                            {
                                matrix[playerRow - 1, playerCol] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = secondPortalBRow;
                                playerCol = secondPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }

                            else if (matrix[playerRow, playerCol] == matrix[secondPortalBRow, secondPortalBCol])
                            {
                                matrix[playerRow - 1, playerCol] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = firstPortalBRow;
                                playerCol = firstPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = 'S';
                            matrix[playerRow - 1, playerCol] = '.';
                        }
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }

                else if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;

                        if (matrix[playerRow, playerCol] == '*')
                        {
                            foodCount++;
                            matrix[playerRow + 1, playerCol] = '.';
                            matrix[playerRow, playerCol] = 'S';

                        }

                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (matrix[playerRow, playerCol] == matrix[firstPortalBRow, firstPortalBCol])
                            {
                                matrix[playerRow + 1, playerCol] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = secondPortalBRow;
                                playerCol = secondPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }

                            else if (matrix[playerRow, playerCol] == matrix[secondPortalBRow, secondPortalBCol])
                            {
                                matrix[playerRow + 1, playerCol] = '.';
                                matrix[playerRow, playerCol] = '.';

                                playerRow = firstPortalBRow;
                                playerCol = firstPortalBCol;
                                matrix[playerRow, playerCol] = 'S';
                            }
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = 'S';
                            matrix[playerRow + 1, playerCol] = '.';
                        }
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }

                }

                if (foodCount == 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }

            }

            Console.WriteLine($"Food eaten: {foodCount}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
