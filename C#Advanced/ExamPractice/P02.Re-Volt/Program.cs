using System;

namespace P02.Re_volt2._0
{
    class Program
    {   // 90/100
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int playerRow = -1;

            int playerCol = -1;

            bool playerPosFound = false;
            bool won = false;

            for (int row = 0; row < size; row++)
            {

                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                if (!playerPosFound)
                {

                    for (int col = 0; col < currentRow.Length; col++)
                    {

                        if (currentRow[col] == 'f')
                        {

                            playerRow = row;

                            playerCol = col;

                            playerPosFound = true;

                            break;

                        }

                    }

                }

                matrix[row] = currentRow;

            }

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                if (command == "down")
                {
                    if (playerRow + 1 < size)
                    {
                        playerRow++;

                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerRow--;
                            continue;
                        }

                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerRow + 1 < size)
                            {
                                playerRow++;
                                matrix[playerRow - 2][playerCol] = '-';
                                matrix[playerRow][playerCol] = 'f';
                            }
                            else
                            {
                                matrix[playerRow - 1][playerCol] = '-';
                                playerRow = 0;
                                matrix[playerRow][playerCol] = 'f';

                            }

                        }

                        else if (matrix[playerRow][playerCol] == 'F')
                        {
                            matrix[playerRow - 1][playerCol] = '-';
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }

                        else
                        {
                            matrix[playerRow - 1][playerCol] = '-';
                            matrix[playerRow][playerCol] = 'f';

                        }

                    }

                    else
                    {
                        if (matrix[0][playerCol] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[0][playerCol] == 'B')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = 1;
                            matrix[playerRow][playerCol] = 'f';
                        }
                        else if (matrix[0][playerCol] == 'F')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = 0;
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = 0;
                            matrix[playerRow][playerCol] = 'f';
                        }
                    }
                }

                else if (command == "up")
                {
                    if (playerRow - 1 >= 0 )
                    {
                        playerRow--;

                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerRow++;
                            continue;
                        }

                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerRow - 1 >= 0)
                            {
                                playerRow--;
                                matrix[playerRow + 2][playerCol] = '-';
                                matrix[playerRow][playerCol] = 'f';
                            }
                            else
                            {
                                matrix[playerRow + 1][playerCol] = '-';
                                playerRow = size - 1;
                                matrix[playerRow][playerCol] = 'f';

                            }

                        }

                        else if (matrix[playerRow][playerCol] == 'F')
                        {
                            matrix[playerRow + 1][playerCol] = '-';
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }

                        else
                        {
                            matrix[playerRow + 1][playerCol] = '-';
                            matrix[playerRow][playerCol] = 'f';

                        }

                    }

                    else
                    {
                        if (matrix[size - 1][playerCol] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[size - 1][playerCol] == 'B')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = size - 2;
                            matrix[playerRow][playerCol] = 'f';
                        }
                        else if (matrix[size - 1][playerCol] == 'F')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = size - 1;
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerRow = size - 1;
                            matrix[playerRow][playerCol] = 'f';
                        }
                    }
                }

                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;

                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerCol++;
                            continue;
                        }

                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerCol - 1 >= 0)
                            {
                                playerCol--;
                                matrix[playerRow][playerCol + 2] = '-';
                                matrix[playerRow][playerCol] = 'f';
                            }
                            else
                            {
                                matrix[playerRow][playerCol + 1] = '-';
                                playerCol = size - 1;
                                matrix[playerRow][playerCol] = 'f';

                            }

                        }

                        else if (matrix[playerRow][playerCol] == 'F')
                        {
                            matrix[playerRow][playerCol + 1] = '-';
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }

                        else
                        {
                            matrix[playerRow ][playerCol + 1] = '-';
                            matrix[playerRow][playerCol] = 'f';

                        }

                    }

                    else
                    {
                        if (matrix[playerRow][size - 1] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[playerRow][size - 1] == 'B')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerCol = size - 2;
                            matrix[playerRow][playerCol] = 'f';
                        }
                        else if (matrix[playerRow][size - 1] == 'F')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerCol = size - 1;
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerCol = size - 1;
                            matrix[playerRow][playerCol] = 'f';
                        }
                    }
                }


                else if (command == "right")
                {
                    if (playerCol + 1 < size)
                    {
                        playerCol++;

                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerCol--;
                            continue;
                        }

                        else if (matrix[playerRow][playerCol] == 'B')
                        {
                            if (playerCol + 1 < size)
                            {
                                playerCol++;
                                matrix[playerRow][playerCol - 2] = '-';
                                matrix[playerRow][playerCol] = 'f';
                            }
                            else
                            {
                                matrix[playerRow][playerCol - 1] = '-';
                                playerCol = 0;
                                matrix[playerRow][playerCol] = 'f';

                            }

                        }

                        else if (matrix[playerRow][playerCol] == 'F')
                        {
                            matrix[playerRow][playerCol - 1] = '-';
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }

                        else
                        {
                            matrix[playerRow][playerCol - 1] = '-';
                            matrix[playerRow][playerCol] = 'f';

                        }

                    }

                    else
                    {
                        if (matrix[playerRow][0] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[playerRow][0] == 'B')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerCol = 1;
                            matrix[playerRow][playerCol] = 'f';
                        }
                        else if (matrix[playerRow][0] == 'F')
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerCol = 0;
                            matrix[playerRow][playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            won = true;
                            break;
                        }
                        else
                        {
                            matrix[playerRow][playerCol] = '-';
                            playerCol = 0;
                            matrix[playerRow][playerCol] = 'f';
                        }
                    }
                }
            }


            if (!won)
            {
                Console.WriteLine("Player lost!");
            }

            foreach(var chArr in matrix)
            {
                foreach(var ch in chArr)
                {
                    Console.Write(ch);
                }

                Console.WriteLine();
            }
            
        }
    }
}
