using System;
using System.Numerics;

namespace Problem03.BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger bigInteger = 1;

            for (int i = number; i > 0; i--)
            {
                bigInteger *= i;

            }

            Console.WriteLine(bigInteger);
        }
    }
}
