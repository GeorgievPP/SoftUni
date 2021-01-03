using System;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintPrice(productName, quantity);
           
        }
        static void PrintPrice(string command, int number)
        {
            double result = 0;
            if (command == "coffee")
            {
                result = number * 1.50;
            }
            else if (command == "coke")
            {
                result = number * 1.40;
            }
            else if (command == "snacks")
            {
                result = number * 2.00;
            }
            else if (command == "water")
            {
                result = number * 1.00;
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}
