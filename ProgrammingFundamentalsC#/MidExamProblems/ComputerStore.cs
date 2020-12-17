using System;

namespace P01.ComputerStore
{
    class PurvoMENE
    { // 12 August 2020
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalPrice = 0.0;

            while(input != "special" && input != "regular")
            {
                double price = double.Parse(input);

                if (price <0)
                {
                    Console.WriteLine("Invalid price!");

                }
                else
                {
                    totalPrice += price;

                }

                input = Console.ReadLine();

            }

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");

            }
            else
            {
                if (input == "regular")
                {
                    double taxes = totalPrice * 0.2;
                    double finalPrice = totalPrice + taxes;
                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                    Console.WriteLine($"Taxes: {taxes:f2}$");
                    Console.WriteLine("-----------");
                    Console.WriteLine($"Total price: {finalPrice:f2}$");
                }
                else if(input == "special")
                {
                    double taxes = totalPrice * 0.2;
                    double finalPrice = totalPrice + taxes;
                    finalPrice -= (finalPrice * 0.1);

                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                    Console.WriteLine($"Taxes: {taxes:f2}$");
                    Console.WriteLine("-----------");
                    Console.WriteLine($"Total price: {finalPrice:f2}$");
                }
            }
        }
    }
}
