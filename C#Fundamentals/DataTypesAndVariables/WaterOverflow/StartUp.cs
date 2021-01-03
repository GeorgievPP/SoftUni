using System;

namespace WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int n = int.Parse(Console.ReadLine());
            int totalLitters = 0;
            int temp = capacity;
            for (int i = 1; i <= n; i++)
            {
                int litters = int.Parse(Console.ReadLine());
                totalLitters += litters;
                temp -= litters;
                if (totalLitters > capacity)
                {
                    temp += litters;
                    totalLitters -= litters;
                    Console.WriteLine("Insufficient capacity!");

                }

            }

            Console.WriteLine(totalLitters);

        }
    }
}
