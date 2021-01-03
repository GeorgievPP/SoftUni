using System;

namespace MethodsExercise
{
    class SmallestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int result =  GetResult(a, b, c);
            Console.WriteLine(result);

        }

        static int GetResult(int a, int b , int c)
        {
            int tempResult = Math.Min(a, b);
            int result = Math.Min(c, tempResult);
            return result;
        }
    }
}
