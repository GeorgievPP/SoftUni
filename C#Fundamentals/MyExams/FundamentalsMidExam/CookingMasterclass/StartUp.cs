using System;

namespace Problem1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            int students = int.Parse(Console.ReadLine());

            double priceForPackageFloor = double.Parse(Console.ReadLine());

            double priceForEgg = double.Parse(Console.ReadLine());

            double priceForApron = double.Parse(Console.ReadLine());

            double aprons = Math.Ceiling((students * 1.0) + (students * 0.2));

            double apronsPrice = aprons * priceForApron;

            double neededEggs = students * 10.0;

            double eggsPrice = priceForEgg * neededEggs;

            int floorPack = 0;

            for(int i = 1; i <= students; i++)
            {
               
                if(i % 5 != 0)
                {
                    floorPack++;

                }
                
            }

            double floorPacksPrice = (floorPack * 1.0) * priceForPackageFloor;

            double totalPrice = floorPacksPrice + eggsPrice + apronsPrice;

            if(totalPrice <= budget)
            {

                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");

            }
            else
            {
                totalPrice -= budget;

                Console.WriteLine($"{totalPrice:f2}$ more needed.");
            }


        }
    }
}
