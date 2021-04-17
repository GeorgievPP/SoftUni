using System;

namespace P02_
{
    class Program
    {
        public class Position
        {
            public Position(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; set; }

            public int Col { get; set; }


            public bool IsSafe(int rowCount, int colCount)
            {
                if (Row < 0 || Col < 0)
                {
                    return false;
                }
                if (Row >= rowCount || Col >= colCount)
                {
                    return false;
                }

                return true;
            }

        }

        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeOfMatrix][];

            Read(matrix);

            bool win = false;
            string text = "";

            int[] arr = new int[2];

            while (!win && lives > 0)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                int targetRow = int.Parse(cmdArgs[1]);
                int targetCol = int.Parse(cmdArgs[2]);

                if(ValidBrawserPosition(matrix, targetRow, targetCol))
                {
                    matrix[targetRow][targetCol] = 'B';
                }

                var player = GetPlayerPosition(matrix);

                if (command == "A")
                {
                    lives -= 1;
                    if (ValidBrawserPosition(matrix, player.Row, player.Col - 1))
                    {
                        matrix[player.Row][player.Col] = '-';
                        if (matrix[player.Row][player.Col- 1] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                matrix[player.Row][player.Col - 1] = 'X';
                                LosePosition(arr, player.Row, player.Col - 1);
                                break;
                            }
                            else
                            {
                                matrix[player.Row][player.Col - 1] = 'M';
                            }
                        }
                        else if (matrix[player.Row][player.Col - 1] == 'P')
                        {
                            matrix[player.Row][player.Col - 1] = '-';
                            matrix[player.Row][player.Col] = '-';
                            win = true;
                            break;
                        }

                        matrix[player.Row][player.Col - 1] = 'M';
                        if (lives <= 0)
                        {
                            matrix[player.Row][player.Col - 1] = 'X';
                            LosePosition(arr, player.Row, player.Col - 1);
                            break;
                        }

                    }
                    if (lives <= 0)
                    {
                        matrix[player.Row][player.Col] = 'X';
                        break;
                    }
                }
                else if (command == "D")
                {
                    lives -= 1;
                    if (ValidBrawserPosition(matrix, player.Row, player.Col + 1))
                    {
                        matrix[player.Row][player.Col] = '-';
                        if (matrix[player.Row][player.Col + 1] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                matrix[player.Row][player.Col + 1] = 'X';
                                LosePosition(arr, player.Row, player.Col + 1);
                                break;
                            }
                            else
                            {
                                matrix[player.Row][player.Col + 1] = 'M';
                            }
                        }
                        else if (matrix[player.Row][player.Col + 1] == 'P')
                        {
                            matrix[player.Row][player.Col + 1] = '-';
                            matrix[player.Row][player.Col] = '-';
                            win = true;
                            break;
                        }

                        matrix[player.Row][player.Col + 1] = 'M';
                        if (lives <= 0)
                        {
                            matrix[player.Row][player.Col + 1] = 'X';
                            LosePosition(arr, player.Row, player.Col + 1);
                            break;
                        }

                    }
                    if (lives <= 0)
                    {
                        matrix[player.Row][player.Col] = 'X';
                        break;
                    }
                }
                else if (command == "W")
                {
                    lives -= 1;
                    if (ValidBrawserPosition(matrix, player.Row - 1, player.Col))
                    {
                        matrix[player.Row][player.Col] = '-';
                        if (matrix[player.Row - 1][player.Col] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                matrix[player.Row - 1][player.Col] = 'X';
                                LosePosition(arr, player.Row - 1, player.Col);
                                break;
                            }
                            else
                            {
                                matrix[player.Row - 1][player.Col] = 'M';
                            }
                        }
                        else if (matrix[player.Row - 1][player.Col] == 'P')
                        {
                            matrix[player.Row - 1][player.Col] = '-';
                            matrix[player.Row][player.Col] = '-';
                            win = true;
                            break;
                        }

                        matrix[player.Row - 1][player.Col] = 'M';
                        if (lives <= 0)
                        {
                            matrix[player.Row - 1][player.Col] = 'X';
                            LosePosition(arr, player.Row - 1, player.Col);
                            break;
                        }

                    }
                    if (lives <= 0)
                    {
                        matrix[player.Row][player.Col] = 'X';
                        break;
                    }

                }
                else if (command == "S")
                {
                    lives -= 1;
                    if (ValidBrawserPosition(matrix, player.Row + 1, player.Col))
                    {
                        matrix[player.Row][player.Col] = '-';
                        if (matrix[player.Row + 1][player.Col] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                matrix[player.Row + 1][player.Col] = 'X';
                                LosePosition(arr, player.Row + 1, player.Col);
                                break;
                            }
                            else
                            {
                                matrix[player.Row + 1][player.Col] = 'M';
                            }
                        }
                        else if (matrix[player.Row + 1][player.Col] == 'P')
                        {
                            matrix[player.Row + 1][player.Col] = '-';
                            matrix[player.Row][player.Col] = '-';
                            win = true;
                            break;
                        }

                        matrix[player.Row + 1][player.Col] = 'M';
                        if (lives <= 0)
                        {
                            matrix[player.Row + 1][player.Col] = 'X';
                            LosePosition(arr, player.Row + 1, player.Col);
                            break;
                        }

                    }
                    if (lives <= 0)
                    {
                        matrix[player.Row][player.Col] = 'X';
                        break;
                    }
                }

              
            }

            if (lives <= 0)
            {
                Console.WriteLine($"Mario died at {arr[0]};{arr[1]}.");
            }
            else if (win)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            Print(matrix);

        }

        public static bool ValidBrawserPosition(char[][] matrix, int row, int col)
        {
            if(row >= 0 && row < matrix.Length)
            {
                if(col >= 0 && col < matrix[row].Length)
                {
                    return true;
                }
            }

            return false;

        }

        private static void LosePosition(int[] losePosition, int row, int col)
        {
            losePosition[0] = row;
            losePosition[1] = col;
        }

        private static Position GetPlayerPosition(char[][] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
        }

        private static void Read(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                char[] currRow = line.ToCharArray();

                matrix[row] = currRow;
            }
        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
