using System;

namespace Problem07.NxNMatrix
{
    class NxNMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ReturnMatrix(n);
        }

        private static void ReturnMatrix(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                ReturnMatrixRow(n);

                Console.WriteLine();
            }
        }

        private static void ReturnMatrixRow(int n)
        {
            for (int j = 1; j <= n; j++)
            {
                Console.Write(n + " ");
            }
        }
    }
}
