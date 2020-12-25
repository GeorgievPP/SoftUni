using System;

namespace PadawanEquipment
{
    class PadawanEquipment
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double lightsabrerPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            // Mechove

            double totalSabrePrice = Math.Ceiling((students + (students * 0.10)));
            totalSabrePrice *= lightsabrerPrice;

            // Robi

            double totalRobePrice = students * robePrice;

            // Kolani
            double totalBeltPrice = 0;
            for(int i = 1; i <= students;i ++)
            {
                totalBeltPrice += beltPrice;

                if (i % 6 == 0)
                {
                    totalBeltPrice -= beltPrice;
                }
            }


            //Total 

            double totalPrice = totalSabrePrice + totalRobePrice + totalBeltPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                totalPrice -= budget;
                Console.WriteLine($"Ivan Cho will need {totalPrice:f2}lv more.");
            }
        }
    }
}
