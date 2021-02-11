using System;
using System.Collections.Generic;

namespace P02.Snake3._0
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
                if(Row < 0 || Col < 0)
                {
                    return false;
                }
                if(Row >= rowCount || Col >= colCount)
                {
                    return false;
                }

                return true;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Read(matrix);
            var player = GetPlayerPosition(matrix);

            int firstBRow = -1;
            int firstBCol = -1;

            int secBRow = -1;
            int secBCol = -1;

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B' && count == 0)
                    {
                        firstBRow = row;
                        firstBCol = col;
                        count++;
                    }
                    if (matrix[row, col] == 'B' && count == 1)
                    {
                        secBRow = row;
                        secBCol = col;
                    }

                }
            }

            int foodCount = 0;

            while (true)
            {
                string command = Console.ReadLine();

                matrix[player.Row, player.Col] = '.';
                if(command == "left")
                {
                    player.Col--;
                    if(!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"Game over!");
                        Console.WriteLine($"Food eaten: {foodCount}");
                        Print(matrix);
                        return;
                    }
                }
                if(command == "right")
                {
                    player.Col++;
                    if(!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"Game over!");
                        Console.WriteLine($"Food eaten: {foodCount}");
                        Print(matrix);
                        return;
                    }
                }
                if(command == "up")
                {
                    player.Row--;
                    if(!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"Game over!");
                        Console.WriteLine($"Food eaten: {foodCount}");
                        Print(matrix);
                        return;
                    }
                }
                if(command == "down")
                {
                    player.Row++;
                    if(!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"Game over!");
                        Console.WriteLine($"Food eaten: {foodCount}");
                        Print(matrix);
                        return;
                    }
                }

                if(matrix[player.Row, player.Col] == 'B')
                {
                    if (matrix[player.Row, player.Col] == matrix[firstBRow, firstBCol])
                    {
                        matrix[player.Row, player.Col] = '.';
                        player.Row = secBRow;
                        player.Col = secBCol;
                    }
                    else if (matrix[player.Row, player.Col] == matrix[secBRow, secBCol])
                    {
                        matrix[player.Row, player.Col] = '.';
                        player.Row = secBRow;
                        player.Col = secBCol;
                    }
                }

                if(matrix[player.Row, player.Col] == '*')
                {
                    foodCount++;
                }

                matrix[player.Row, player.Col] = 'S';

                if (foodCount >= 10)
                {
                    Console.WriteLine($"You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {foodCount}");
                    Print(matrix);
                    return;
                }
            }
            
        }


       
        static Position GetPlayerPosition(char[,] matrix)
        {
            Position position = null;
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 'S')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
        }

        private static void Read(char[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        private static void Print(char[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
