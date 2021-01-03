using System;

namespace DisneylandJourney
{
    class DisneylandJourney
    {
        static void Main(string[] args)
        { // 10 DEC 2019
            double journeyWillCoast = double.Parse(Console.ReadLine());

            int months = int.Parse(Console.ReadLine());

            double saves = 0;

            double monthSaves = journeyWillCoast * 0.25;

            for(int i = 1; i <= months; i++)
            {
                if (i > 1 && i % 2 == 1)
                {
                    saves -= (saves * 0.16);

                }
                if ( i % 4 == 0)
                {
                    saves += (saves * 0.25);

                }

                saves += monthSaves;

            }

            if(saves >= journeyWillCoast)
            {
                saves -= journeyWillCoast;

                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {saves:f2}lv. for souvenirs.");

            }
            else
            {
                journeyWillCoast -= saves;

                Console.WriteLine($"Sorry. You need {journeyWillCoast:f2}lv. more.");
            }
        }
    }
}
