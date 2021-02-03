using System;
using System.Linq;
using System.Text;

namespace P06.JaggedArrayModification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const string ADD_COMMAND = "Add";
            const string SUBTRACT_COMMAND = "Subtract";

            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = ReadJaggedArray(rows);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {

                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (matrix.Length <= row || row < 0
                    || matrix[row].Length <= col || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else
                {
                    if (command.Equals(ADD_COMMAND))
                    {
                        matrix[row][col] += value;
                    }

                    else if (command.Equals(SUBTRACT_COMMAND))
                    {
                        matrix[row][col] -= value;
                    }
                }
            }

            PrintJaggedArray(matrix);
        }

        private static void PrintJaggedArray(int[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in matrix)
            {
                sb.AppendLine(String.Join(" ", row));
            }

            Console.WriteLine(sb.ToString());
        }

        private static int[][] ReadJaggedArray(int rows)
        {
            int[][] matrix = new int[rows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new int[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
