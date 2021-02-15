using System;

namespace P02.Re_Volt3._0
{
    class Program
    {
        public class Position
        {
            public Position(int row, int col)
            {
                Col = col;
                Row = row;
            }

            public int Row { get; set; }

            public int Col { get; set; }


            public bool IsSafe(int rowCount, int colCount)
            {
                if(Row < 0 || Col < 0)
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
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Read(matrix);
            var player = GetPlayerPosition(matrix);
            if(commands > 0)
            {
                matrix[player.Row, player.Col] = '-';
            }

            for(int i = 0; i < commands; i++)
            {
                string command = Console.ReadLine();
                MovePlayer(player, command, n);
                while(matrix[player.Row, player.Col] == 'B')
                {
                    MovePlayer(player, command, n);
                }

                while(matrix[player.Row, player.Col] == 'T')
                {
                    Position direction = GetDirection(command);
                    player.Row += direction.Row * -1;
                    player.Col += direction.Col * -1;
                }

                if(matrix[player.Row, player.Col] == 'F')
                {
                    Console.WriteLine($"Player won!");
                    matrix[player.Row, player.Col] = 'f';
                    Print(matrix);
                    return;
                }

            }

            Console.WriteLine($"Player lost!");
            matrix[player.Row, player.Col] = 'f';

            Print(matrix);

        }

        static Position GetDirection(string command)
        {
            int row = 0;
            int col = 0;
            if(command == "left")
            {
                col = -1;
            }
            if (command == "right")
            {
                col = 1;
            }
            if (command == "up")
            {
                row = -1;
            }
            if (command == "down")
            {
                row = 1;
            }

            return new Position(row, col);
        }


        static Position MovePlayer(Position player, string command, int n)
        {
            if (command == "left")
            {
                player.Col--;
                if (!player.IsSafe(n, n))
                {
                    player.Col = n - 1;
                }
            }
            if (command == "right")
            {
                player.Col++;
                if (!player.IsSafe(n, n))
                {
                    player.Col = 0;
                }
            }
            if (command == "up")
            {
                player.Row--;
                if (!player.IsSafe(n, n))
                {
                    player.Row = n - 1;
                }
            }
            if (command == "down")
            {
                player.Row++;
                if (!player.IsSafe(n, n))
                {
                    player.Row = 0;
                }
            }

            return player;
        }

        static Position GetPlayerPosition(char[,] matrix)
        {
            Position position = null;
            for(int row =0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 'f')
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
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col  = 0; col< matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }




    }
}
