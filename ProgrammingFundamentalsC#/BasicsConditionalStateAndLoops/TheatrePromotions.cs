using System;

namespace TheatrePromotions
{
    class TheatrePromotions
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int price = 0;
            bool ageTrue = true;

            if (day == "Weekday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 12;
                }
                else if (age > 18 && age <= 64)
                {
                    price = 18;
                }
                else if (age > 64 && age <= 122)
                {
                    price = 12;
                }
                else
                {
                    ageTrue = false;
                }
            }
            else if ( day == "Weekend")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    price = 20;
                }
                else if (age > 64 && age <= 122)
                {
                    price = 15;
                }
                else
                {
                    ageTrue = false;
                }
            }
            else if (day == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 5;
                }
                else if (age > 18 && age <= 64)
                {
                    price = 12;
                }
                else if (age > 64 && age <= 122)
                {
                    price = 10;
                }
                else
                {
                    ageTrue = false;
                }
            }

            if (ageTrue)
            {
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
