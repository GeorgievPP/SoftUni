using System;

namespace Problem05.AddAndSubstract
{
    class AddAndSubstract
    {
        static void Main(string[] args)
        {
            long a = long.Parse(Console.ReadLine());

            long b = long.Parse(Console.ReadLine());

            long c = long.Parse(Console.ReadLine());

            Console.WriteLine(GetSubstactedSum(a, b, c));


        }

        static long GetSum(long a, long b)
        {
            long sum = a + b;

            return sum;
        }

        static long GetSubstactedSum(long a, long b, long c)
        {
            long finalSum = GetSum(a, b) - c;

            return finalSum;
        }
    }
}
