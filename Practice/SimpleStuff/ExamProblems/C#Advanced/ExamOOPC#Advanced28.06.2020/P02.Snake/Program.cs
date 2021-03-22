using System;

namespace P02.Snake
{
    class Program
    {
        public class Position
        {
            public Position(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public bool IsSafe(int rowCount, int colCount)
            {
                if(this.Row < 0 || this.Col < 0)
                {
                    return false;
                }

                if(this .Row >= rowCount || this.Col >= colCount)
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

            var player = GetPosition(matrix);

            int firstBRow = -1;
            int firstBCol = -1;

            int secBRow = -1;
            int secBCol = -1;

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 'B' && count == 0)
                    {
                        firstBRow = row;
                        firstBCol = col;
                        count++;
                    }

                    if(matrix[row,col] == 'B' && count == 1)
                    {
                        secBRow = row;
                        secBCol = col;
                    }
                }
            }

            int foodCount = 0;
            bool gameOver = false;

            while (true)
            {
                string command = Console.ReadLine();

                matrix[player.Row, player.Col] = '.';
                if(command == "left")
                {
                    player.Col--;
                    if (!player.IsSafe(n, n))
                    {
                        gameOver = true;
                        break;
                    }
                }

                if(command == "right")
                {
                    player.Col++;
                    if(!player.IsSafe(n, n))
                    {
                        gameOver = true;
                        break;
                    }
                }

                if(command == "up")
                {
                    player.Row--;
                    if(!player.IsSafe(n, n))
                    {
                        gameOver = true;
                        break;
                    }
                }

                if(command == "down")
                {
                    player.Row++;
                    if(!player.IsSafe(n, n))
                    {
                        gameOver = true;
                        break;
                    }
                }

                if(matrix[player.Row, player.Col] == 'B')
                {
                    matrix[player.Row, player.Col] = '.';

                    if (matrix[player.Row, player.Col] == matrix[firstBRow, firstBCol])
                    {
                        player.Row = secBRow;
                        player.Col = secBCol;
                    }
                    else if(matrix[player.Row, player.Col] == matrix[secBRow, secBCol])
                    {
                        player.Row = firstBRow;
                        player.Col = firstBCol;
                    }
                }

                if (matrix[player.Row, player.Col] == '*')
                {
                    foodCount++;
                }

                matrix[player.Row, player.Col] = 'S';

                if(foodCount >= 10)
                {
                    break;
                }
            }

            if (gameOver)
            {
                Console.WriteLine($"Game over!");
            }
            else
            {
                Console.WriteLine($"You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCount}");
            Print(matrix);

        }

        public static Position GetPosition(char[,] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 'S')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
        }

        public static void Read(char[,] matrix)
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
