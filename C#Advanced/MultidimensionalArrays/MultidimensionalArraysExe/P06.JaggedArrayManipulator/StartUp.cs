using System;
using System.Linq;

namespace P06.JaggedArrayManipulator2._0
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const string END_COMMAND = "End";
            const string ADD_COMMAND = "Add";

            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = ReadJaggedArray(rows);

            for (int row = 0; row < rows - 1; row++)
            {
                double[] line = jaggedArray[row];
                double[] line2 = jaggedArray[row + 1];

                if (line.Length.Equals(line2.Length))
                {
                    jaggedArray[row] = Multiplier(line);
                    jaggedArray[row + 1] = Multiplier(line2);
                }
                else
                {
                    jaggedArray[row] = Devider(line);
                    jaggedArray[row + 1] = Devider(line2);
                }
            }

            string input;
            while (!(input = Console.ReadLine()).Equals(END_COMMAND))
            {
                string[] cmdArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (ValidateCommand(jaggedArray, command, row, col))
                {
                    if (command.Equals(ADD_COMMAND))
                    {
                        jaggedArray[row][col] += value;
                    }
                    else
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            PrintJaggedArray(jaggedArray);

        }

        private static double[][] ReadJaggedArray(int rows)
        {
            double[][] jaggedArray = new double[rows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ');
                jaggedArray[row] = new double[rowData.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = double.Parse(rowData[col]);
                }
            }

            return jaggedArray;
        }

        private static double[] Multiplier(double[] line)
        {
            line = line.Select(l => l * 2).ToArray();
            return line;
        }

        private static double[] Devider(double[] line)
        {
            line = line.Select(l => l / 2.0).ToArray();
            return line;
        }

        public static void PrintJaggedArray(double[][] jagged)
        {
            foreach (var line in jagged)
            {
                Console.WriteLine(String.Join(" ", line));
            }
        }

        private static bool ValidateCommand(double[][] jagged, string command, int row, int col)
        {
            bool validator = (command.Equals("Add") || command.Equals("Subtract"))
                && (row >= 0 && row < jagged.Length)
                && (col >= 0 && col < jagged[row].Length);

            if (validator)
            {
                return true;
            }

            return false;
        }
    }
}
