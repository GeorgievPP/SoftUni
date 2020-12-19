using System;

namespace CatExpenses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double catBed = double.Parse(Console.ReadLine());
            double catToilet = double.Parse(Console.ReadLine());
            double catFood = catToilet + (catToilet * 0.25);
            double catToys = catFood / 2.0;
            double vet = catToys + (catToys * 0.1);
            double total = catToilet + catFood+ catToys+ vet;
            double plus = total * 0.05;
            double totalYear = catBed + (12 * total) + (12 * plus);
            Console.WriteLine($"{totalYear:f2} lv.");
        }
    }
}
