using System;

namespace RageExpenses
{
    class RageExpenses
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());


            double total = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 12 == 0)
                {
                    total += displayPrice; 
                }
                if (i % 6 == 0)
                {
                    total += keyboardPrice;
                }
                if (i % 3 == 0)
                {
                    total += mousePrice;
                }
                if ( i % 2 == 0)
                {
                    total += headsetPrice;
                }
            }
            Console.WriteLine($"Rage expenses: {total:f2} lv.");

        }
    }
}
