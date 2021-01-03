using System;

namespace P01.EasterCozonacs
{
    class EasterCozonacs
    {
        static void Main(string[] args)
        { // 16.April.2019
            double budget = double.Parse(Console.ReadLine());

            double pricePerKgFloor = double.Parse(Console.ReadLine());

            int eggs = 0;
            int count = 0;

            double eggsPrice = pricePerKgFloor * 0.75;

            double priceLitterMilk = pricePerKgFloor + (pricePerKgFloor * 0.25);

            double milkPerCozonac = priceLitterMilk * 0.25;

            double totalPriceForOneCozonac = pricePerKgFloor + eggsPrice + milkPerCozonac;

            while (budget >= totalPriceForOneCozonac)
            {
                count++;

                budget -= totalPriceForOneCozonac;
                eggs += 3;

                if (count % 3 == 0)
                {
                    eggs -= (count - 2);
                }
            }

            Console.WriteLine($"You made {count} cozonacs! Now you have {eggs} eggs and {budget:f2}BGN left.");

        }
    }
}
