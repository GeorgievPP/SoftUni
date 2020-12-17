using System;

namespace MathOperations
{
    class MathOperations
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            double totalResult = GetResult(a, operation, b);

            Console.WriteLine(Math.Round(totalResult, 2));
           
        }
        static double GetResult(int a, string option, int b)
        {
            double result = 0;
            if (option == "+")
            {
                result = a + b;
            }
            else if (option == "-")
            {
                result = a - b;
            }
            else if (option == "/")
            {
                result = a * 1.0 / b;
            }
            else if (option == "*")
            {
                result = a * b;
            }

            return result;
        }
    }
}
