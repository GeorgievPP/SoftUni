﻿using System;

namespace BackIn30Minutes
{
    class BackIn30Minutes
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

         
            minutes += 30;

            if (minutes > 59)
            {
                hours++;
                minutes -= 60;
                if (hours > 23)
                {
                    hours = 0;
                }
                
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
           
            

        }
    }
}
