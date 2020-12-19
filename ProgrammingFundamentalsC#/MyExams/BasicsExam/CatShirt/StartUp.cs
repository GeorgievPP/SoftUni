using System;
using System.Runtime.CompilerServices;

namespace CatShirt
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double sleeveSize = double.Parse(Console.ReadLine());
            double frontSize = double.Parse(Console.ReadLine());
            string cloth = Console.ReadLine();
            string tie = Console.ReadLine();

            double shirtSize = (sleeveSize * 2) + (frontSize * 2);
            shirtSize += (shirtSize * 0.10);
            shirtSize /= 100.0;

            if(cloth == "Linen")
            {
                shirtSize *= 15.0;
            }
            else if (cloth == "Cotton")
            {
                shirtSize *= 12.0;
            }
            else if (cloth == "Denim")
            {
                shirtSize *= 20.0;
            }
            else if (cloth == "Twill")
            {
                shirtSize *= 16.0;
            }
            else if (cloth == "Flannel")
            {
                shirtSize *= 11.0;
            }

            shirtSize += 10;

            if (tie == "Yes")
            {
                shirtSize += (shirtSize * 0.20);
                Console.WriteLine($"The price of the shirt is: {shirtSize:f2}lv.");
            }
            else if (tie == "No")
            {
                Console.WriteLine($"The price of the shirt is: {shirtSize:f2}lv.");
            }
        }
    }
}
