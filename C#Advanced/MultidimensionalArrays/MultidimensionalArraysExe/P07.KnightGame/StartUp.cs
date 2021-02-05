using System;

namespace P07.KnightGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countReplaced = 0;

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            FillMatrix(matrix);

            while (true)
            {
                int rowKiller = 0;
                int colKiller = 0;
                int maxAttacks = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int countAttacks = 0;
                        char currentSymbol = matrix[row, col];

                        if (currentSymbol == 'K')
                        {
                            if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                countAttacks++;
                            }

                            if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                countAttacks++;
                            }

                            if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                countAttacks++;
                            }

                            if (IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                countAttacks++;
                            }

                            if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                countAttacks++;
                            }

                            if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                countAttacks++;
                            }

                            if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                countAttacks++;
                            }

                            if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                countAttacks++;
                            }

                            if (countAttacks > maxAttacks)
                            {
                                maxAttacks = countAttacks;
                                rowKiller = row;
                                colKiller = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    matrix[rowKiller, colKiller] = '0';
                    countReplaced++;
                }

                else if (maxAttacks <= 0)
                {
                    Console.WriteLine(countReplaced);
                    break;
                }
            }
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static bool IsInside(char[,] chessBoard, int targetRow, int targetCol)
        {

            return targetRow >= 0 && targetRow < chessBoard.GetLength(0)
                && targetCol >= 0 && targetCol < chessBoard.GetLength(1);

        }


    }
}
