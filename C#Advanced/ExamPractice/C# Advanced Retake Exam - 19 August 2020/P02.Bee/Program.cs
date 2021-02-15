using System;

namespace P02.Bee3._0
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

            int countFlowers = 0;

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                matrix[player.Row, player.Col] = '.';
                if(command == "left")
                {
                    player.Col--;
                    if(!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"The bee got lost!");
                        break;
                    }
                }
                if (command == "right")
                {
                    player.Col++;
                    if (!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"The bee got lost!");
                        break;
                    }
                }
                if (command == "up")
                {
                    player.Row--;
                    if (!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"The bee got lost!");
                        break;
                    }
                }
                if (command == "down")
                {
                    player.Row++;
                    if (!player.IsSafe(n, n))
                    {
                        Console.WriteLine($"The bee got lost!");
                        break;
                    }
                }

                if(matrix[player.Row, player.Col] == 'O')
                {
                    matrix[player.Row, player.Col] = '.';
                    if (command == "left")
                    {
                        player.Col--;
                        if (!player.IsSafe(n, n))
                        {
                            Console.WriteLine($"The bee got lost!");
                            break;
                        }
                    }
                    if (command == "right")
                    {
                        player.Col++;
                        if (!player.IsSafe(n, n))
                        {
                            Console.WriteLine($"The bee got lost!");
                            break;
                        }
                    }
                    if (command == "up")
                    {
                        player.Row--;
                        if (!player.IsSafe(n, n))
                        {
                            Console.WriteLine($"The bee got lost!");
                            break;
                        }
                    }
                    if (command == "down")
                    {
                        player.Row++;
                        if (!player.IsSafe(n, n))
                        {
                            Console.WriteLine($"The bee got lost!");
                            break;
                        }
                    }
                }

                if(matrix[player.Row, player.Col] == 'f')
                {
                    countFlowers++;
                }

                matrix[player.Row, player.Col] = 'B';
            }

            if(countFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - countFlowers} flowers more");
            }

            Print(matrix);

        }

        static Position GetPlayerPosition(char[,] matrix)
        {
            Position position = null;
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 'B')
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
