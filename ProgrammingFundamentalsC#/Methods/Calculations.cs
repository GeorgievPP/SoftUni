using System;

namespace Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            string calculation = Console.ReadLine().ToLower();

            PrintCalculation(calculation);
          
        }
        static void PrintCalculation (string command)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int result = 0;
            if (command == "add")
            {
                result = GetAdd(num1, num2);
            }
            else if (command == "multiply")
            {
                result = GetMultiply(num1, num2);
            }
            else if (command == "subtract")
            {
                result = GetSubstract(num1, num2);
            }
            else if (command == "divide")
            {
                result = GetDivide(num1, num2);
            }

            Console.WriteLine(result);
        }

        static int GetAdd(int a , int b)
        {
            return a + b;
        }
        static int GetMultiply(int a, int b)
        {
            return a * b;
        }
        static int GetSubstract(int a, int b)
        {
            return a - b;
        }
        static int GetDivide(int a, int b)
        {
            return a / b;
        }
    }
}
