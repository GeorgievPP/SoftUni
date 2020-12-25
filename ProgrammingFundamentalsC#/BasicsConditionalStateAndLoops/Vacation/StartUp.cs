using System;

namespace Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;
            double priceHelp = 0;

            if (typeOfGroup == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price = people * 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = people * 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = people * 10.46;
                }
                if (people >= 30)
                {
                    price -= (price * 0.15);
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    price = people * 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = people * 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = people * 16.00;
                }
                if (people >= 100)
                {
                    priceHelp = (price / (people * 1.0)) * 10;
                    price -= priceHelp;
                    
                }
            }
            else if (typeOfGroup == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = people * 15.00;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = people * 20.00;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = people * 22.50;
                }
                if (people >= 10 && people <= 20)
                {
                    price -= (price * 0.05);
                }
            }

            Console.WriteLine($"Total price: {price:f2}");


        }
    }
}
