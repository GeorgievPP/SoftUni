using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.SimpleCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split(' ')
                .Reverse().ToArray();

            Stack<string> stack = new Stack<string>(expression);

            while (stack.Count > 1)
            {
                // PrintStack(stack);

                int first = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int second = int.Parse(stack.Pop());

                CalculateStackStepByStep(stack, first, sign, second);
            }

            Console.WriteLine(stack.Pop());
        }

        private static void CalculateStackStepByStep(Stack<string> stack, int first, string sign, int second)
        {
            switch (sign)
            {
                case "+":
                    stack.Push((first + second).ToString());
                    break;
                case "-":
                    stack.Push((first - second).ToString());
                    break;
                default:
                    break;
            }
        }




        /*
        static void PrintStack(Stack<string> stack)
        {
            foreach(var item in stack)
            {
                Console.Write(item);

            }

            Console.WriteLine();
        } */
    }
}
