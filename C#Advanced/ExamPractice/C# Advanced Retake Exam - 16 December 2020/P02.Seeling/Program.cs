using System;
using System.Text;

namespace P02.Selling
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


            public bool IsSafe(int rows, int cols)
            {
                if (Row < 0 || Col < 0)
                {
                    return false;
                }

                if (Row >= rows || Col >= cols)
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
            bool outOfBakery = false;

            int firstPortalRow = -1;
            int firstPortalCol = -1;

            int secondPortalRow = -1;
            int secondPortalCol = -1;

            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O' && count == 0)
                    {
                        firstPortalRow = row;
                        firstPortalCol = col;
                        count++;
                    }
                    if (matrix[row, col] == 'O' && count == 1)
                    {
                        secondPortalRow = row;
                        secondPortalCol = col;
                    }
                }
            }

            int sum = 0;
            while (true)
            {
                string command = Console.ReadLine();

                matrix[player.Row, player.Col] = '-';
                if (command == "left")
                {
                    player.Col--;
                    if (!player.IsSafe(n, n))
                    {
                        outOfBakery = true;
                        break;
                    }
                }
                if (command == "right")
                {
                    player.Col++;
                    if (!player.IsSafe(n, n))
                    {
                        outOfBakery = true;
                        break;
                    }
                }
                if (command == "up")
                {
                    player.Row--;
                    if (!player.IsSafe(n, n))
                    {
                        outOfBakery = true;
                        break;
                    }
                }
                if (command == "down")
                {
                    player.Row++;
                    if (!player.IsSafe(n, n))
                    {
                        outOfBakery = true;
                        break;
                    }
                }

                if (matrix[player.Row, player.Col] == 'O')
                {
                    matrix[player.Row, player.Col] = '-';
                    if (matrix[player.Row, player.Col] == matrix[firstPortalRow, firstPortalCol])
                    {
                        player.Row = secondPortalRow;
                        player.Col = secondPortalCol;
                    }
                    else if (matrix[player.Row, player.Col] == matrix[secondPortalRow, secondPortalCol])
                    {
                        player.Row = firstPortalRow;
                        player.Col = firstPortalCol;
                    }
                }

                if (Char.IsDigit(matrix[player.Row, player.Col]))
                {
                    string number = matrix[player.Row, player.Col].ToString();
                    sum += int.Parse(number);
                }

                matrix[player.Row, player.Col] = 'S';

                if (sum >= 50)
                {
                    break;
                }

            }

            StringBuilder sb = new StringBuilder();

            if (outOfBakery)
            {
                sb.AppendLine($"Bad news, you are out of the bakery.");
            }
            else
            {
                sb.AppendLine($"Good news! You succeeded in collecting enough money!");
            }

            sb.AppendLine($"Money: {sum}");
            Console.WriteLine(sb.ToString().TrimEnd());

            Print(matrix);
        }

        private static Position GetPosition(char[,] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
        }

        private static void Read(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        private static void Print(char[,] matrix)
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
    }
}
