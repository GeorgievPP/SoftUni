using System;

namespace Problem08.FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            long num1 = long.Parse(Console.ReadLine());

            long num2 = long.Parse(Console.ReadLine());

            decimal totalSum = (GetFactorial(num1) * 1.0m) / (GetFactorial(num2) * 1.0m);

            Console.WriteLine($"{totalSum:f2}");

        }

        private static long GetFactorial(long num)
        {
            long sum = 1;

            for (int i = 1; i <= num; i++)
            {
                sum *= i;
            }

            return sum;
        }
    }
}
