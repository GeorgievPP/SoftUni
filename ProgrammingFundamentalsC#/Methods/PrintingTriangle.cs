using System;

namespace PrintingTriangle
{
    class PrintingTriangle
    {
        static void Main(string[] args)
        {
            int sizeTriangle = int.Parse(Console.ReadLine());

            PrintTriangle(sizeTriangle);
          
            
        }
        static void PrintTriangle(int number)
        {
            PrintUpperSide(number);
            PrintLowerSide(number);
        }
        static void PrintUpperSide(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(k + " ");
                }

                Console.WriteLine();

            }
        }
        static void PrintLowerSide(int n)
        {
            for (int i = n - 1; i > 0; i--)
            {
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
