using System;

namespace BeerKegs
{
    class BeerKegs
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            string biggestKeg = "";
            double volumeMax = 0;

            for (int i = 1; i <= n; i++)
            {
                string modelKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * (radius * radius) * (height * 1.00);

                if (volumeMax < volume)
                {
                    biggestKeg = modelKeg;
                    volumeMax = volume;
                }

            }

            Console.WriteLine(biggestKeg);
        }
    }
}
