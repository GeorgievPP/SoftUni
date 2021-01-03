using System;

namespace SingOfIntegerNumber
{
    class SignOfIntegerNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTheSign(number);
            
        }

        static void PrintTheSign(int n)
        {
            if (n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }
            else if (n < 0)
            {
                Console.WriteLine($"The number {n} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {n} is zero.");
            }
        }
    }
}
