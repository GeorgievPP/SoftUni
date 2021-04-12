using System;
using System.Linq;

namespace P02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            string[] coordinates = Console.ReadLine()
                                 .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();
            string[,] matrix = new string[sizeOfMatrix, sizeOfMatrix];
            ReadMatrix(matrix);

            int playerOneShips = 0;
            int playerTwoShips = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "<")
                    {
                        playerOneShips++;
                    }

                    if (matrix[row, col] == ">")
                    {
                        playerTwoShips++;
                    }
                }
            }

            int totalShips = playerOneShips + playerOneShips;
            int playerOneDestroyed = 0;
            int playerTwoDestroyed = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentCoordinates = coordinates[i]
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();
                int currRow = currentCoordinates[0];
                int currCol = currentCoordinates[1];

                if (!IsPositionValid(currRow, currCol, sizeOfMatrix, sizeOfMatrix))
                {
                    continue;
                }

                if (IsPositionValid(currRow, currCol, sizeOfMatrix, sizeOfMatrix))
                {
                    if (matrix[currRow, currCol] == "<")
                    {
                        playerOneShips--;
                        playerOneDestroyed++;
                        matrix[currRow, currCol] = "X";
                    }
                    else if (matrix[currRow, currCol] == ">")
                    {
                        playerTwoShips--;
                        playerTwoDestroyed++;
                        matrix[currRow, currCol] = "X";
                    }
                    else if (matrix[currRow, currCol] == "#")
                    {
                        matrix[currRow, currCol] = "X";

                        if (IsPositionValid(currRow, currCol + 1, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow, currCol + 1] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow, currCol + 1] = "X";
                            }
                            else if (matrix[currRow, currCol + 1] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow, currCol + 1] = "X";
                            }
                            else if (matrix[currRow, currCol + 1] == "*")
                            {
                                matrix[currRow, currCol + 1] = "X";
                            }
                        }

                        if (IsPositionValid(currRow, currCol - 1, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow, currCol - 1] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow, currCol - 1] = "X";
                            }
                            else if (matrix[currRow, currCol - 1] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow, currCol - 1] = "X";
                            }
                            else if (matrix[currRow, currCol - 1] == "*")
                            {
                                matrix[currRow, currCol - 1] = "X";
                            }
                        }

                        if (IsPositionValid(currRow - 1, currCol - 1, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow - 1, currCol - 1] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow - 1, currCol - 1] = "X";
                            }
                            else if (matrix[currRow - 1, currCol - 1] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow - 1, currCol - 1] = "X";
                            }
                            else if (matrix[currRow - 1, currCol - 1] == "*")
                            {
                                matrix[currRow - 1, currCol - 1] = "X";
                            }
                        }

                        if (IsPositionValid(currRow - 1, currCol, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow - 1, currCol] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow - 1, currCol] = "X";
                            }
                            else if (matrix[currRow - 1, currCol] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow - 1, currCol] = "X";
                            }
                            else if (matrix[currRow - 1, currCol] == "*")
                            {
                                matrix[currRow - 1, currCol] = "X";
                            }
                        }

                        if (IsPositionValid(currRow - 1, currCol + 1, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow - 1, currCol + 1] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow - 1, currCol + 1] = "X";
                            }
                            else if (matrix[currRow - 1, currCol + 1] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow - 1, currCol + 1] = "X";
                            }
                            else if (matrix[currRow - 1, currCol + 1] == "*")
                            {
                                matrix[currRow - 1, currCol + 1] = "X";
                            }
                        }

                        if (IsPositionValid(currRow + 1, currCol - 1, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow + 1, currCol - 1] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow + 1, currCol - 1] = "X";
                            }
                            else if (matrix[currRow + 1, currCol - 1] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow + 1, currCol - 1] = "X";
                            }
                            else if (matrix[currRow + 1, currCol - 1] == "*")
                            {
                                matrix[currRow + 1, currCol - 1] = "X";
                            }
                        }

                        if (IsPositionValid(currRow + 1, currCol, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow + 1, currCol] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow + 1, currCol] = "X";
                            }
                            else if (matrix[currRow + 1, currCol] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow + 1, currCol] = "X";
                            }
                            else if (matrix[currRow + 1, currCol] == "*")
                            {
                                matrix[currRow + 1, currCol] = "X";
                            }
                        }

                        if (IsPositionValid(currRow + 1, currCol + 1, sizeOfMatrix, sizeOfMatrix))
                        {
                            if (matrix[currRow + 1, currCol + 1] == "<")
                            {
                                playerOneShips--;
                                playerOneDestroyed++;
                                matrix[currRow + 1, currCol + 1] = "X";
                            }
                            else if (matrix[currRow + 1, currCol + 1] == ">")
                            {
                                playerTwoShips--;
                                playerTwoDestroyed++;
                                matrix[currRow + 1, currCol + 1] = "X";
                            }
                            else if (matrix[currRow + 1, currCol + 1] == "*")
                            {
                                matrix[currRow + 1, currCol + 1] = "X";
                            }
                        }
                    }
                }
            }

            if (playerOneShips > 0 && playerTwoShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
            else if (playerTwoShips == 0)
            {
                Console.WriteLine($"Player One has won the game! { playerOneDestroyed + playerTwoDestroyed} ships have been sunk in the battle.");
            }
            else if (playerOneShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {playerOneDestroyed + playerTwoDestroyed} ships have been sunk in the battle.");
            }
        }

        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] line = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        private static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }

            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
