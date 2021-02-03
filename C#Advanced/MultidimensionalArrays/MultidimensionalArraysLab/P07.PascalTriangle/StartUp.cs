using System;
using System.Text;

namespace P07.PascalTriangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];
            int cols = 1;

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[cols];
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < pascal[row].Length - 1; col++)
                    {
                        long[] prevRow = pascal[row - 1];
                        long firstNum = prevRow[col];
                        long secondNum = prevRow[col - 1];
                        pascal[row][col] = firstNum + secondNum;
                    }
                }

                cols++;
            }

            PrintJaggedArray(pascal);
        }

        private static void PrintJaggedArray(long[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in matrix)
            {
                sb.AppendLine(String.Join(" ", row));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
