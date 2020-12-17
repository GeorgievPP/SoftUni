using System;

namespace P01.NationalCourt
{
    class NationaCourt
    {// 29 FEB 2020 Group 2
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());

            int second = int.Parse(Console.ReadLine());

            int third = int.Parse(Console.ReadLine());

            int peopleCount = int.Parse(Console.ReadLine());

            int peoplePerHour = first + second + third;

            int hours = 0;
            while (peopleCount > 0)
            {
                peopleCount -= peoplePerHour;
                hours++;
                if(hours % 4 == 0)
                {
                    hours++;

                }
            }

            Console.WriteLine($"Time needed: {hours}h.");


        }
    }
}
