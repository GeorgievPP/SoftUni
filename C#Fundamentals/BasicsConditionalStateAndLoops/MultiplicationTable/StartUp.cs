using System;
using System.Runtime.Serialization.Formatters;

namespace MultiplicationTable
{
    class MultiplicationTable
    {
        static void Main(string[] args)
        {
            int multiplier = int.Parse(Console.ReadLine());

            int sum = 0;

            for ( int i = 1; i <= 10; i++)
            {
                sum = multiplier * i;
                Console.WriteLine($"{multiplier} X {i} = {sum}");
                sum = 0;
            }

        }
    }
}
