using System;

namespace MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int multiplier1 = int.Parse(Console.ReadLine());
            int multiplier2 = int.Parse(Console.ReadLine());

            int sum = 0;

            if (multiplier2 > 10)
            {
                sum = multiplier1 * multiplier2;
                Console.WriteLine($"{multiplier1} X {multiplier2} = {sum}"); 
            }
            else
            {
                for (int i = multiplier2; i <= 10; i++)
                {
                    sum = multiplier1 * i;
                    Console.WriteLine($"{multiplier1} X {i} = {sum}");

                }
            }
        }
    }
}
