using System;

namespace ExcursionSale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int seaPackage = int.Parse(Console.ReadLine());
            int mountPackage = int.Parse(Console.ReadLine());
            string namePack = Console.ReadLine();

            double profit = 0.0;

            while(namePack != "Stop")
            {
                if (namePack == "sea")
                {
                    if (seaPackage != 0)
                    {
                        profit += 680;
                    }
                    seaPackage -= 1;
                    if (seaPackage < 0)
                    {
                        seaPackage = 0;
                    }
                }
                else if (namePack == "mountain")
                {
                   
                    if (mountPackage != 0)
                    {
                        profit += 499;
                    }
                    mountPackage -= 1;
                    if (mountPackage < 0)
                    {
                        mountPackage = 0;
                    }
                }
                if (seaPackage == 0 && mountPackage == 0)
                {
                    Console.WriteLine("Good job! Everything is sold.");
                    break;
                }

                namePack = Console.ReadLine(); 
            }

            Console.WriteLine($"Profit: {profit} leva.");
        }
    }
}
