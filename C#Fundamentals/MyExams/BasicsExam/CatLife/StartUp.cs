using System;

namespace CatLife
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string cat = Console.ReadLine();
            char gender = char.Parse(Console.ReadLine());
            
            double catMonth = 0.0;

            if (gender == 'm')
            {
                if (cat == "British Shorthair")
                {
                    catMonth = (13 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Siamese")
                {
                    catMonth = (15 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Persian")
                {
                    catMonth = (14 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Ragdoll")
                {
                    catMonth = (16 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "American Shorthair")
                {
                    catMonth = (12 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Siberian")
                {
                    catMonth = (11 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else
                {
                    Console.WriteLine($"{cat} is invalid cat!");
                }
            }
            else if (gender == 'f')
            {
                if (cat == "British Shorthair")
                {
                    catMonth = (14 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Siamese")
                {
                    catMonth = (16 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Persian")
                {
                    catMonth = (15 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Ragdoll")
                {
                    catMonth = (17 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "American Shorthair")
                {
                    catMonth = (13 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else if (cat == "Siberian")
                {
                    catMonth = (12 * 12) / 6.0;
                    Console.WriteLine($"{Math.Floor(catMonth)} cat months");
                }
                else
                {
                    Console.WriteLine($"{cat} is invalid cat!");
                }
            }

        }
    }
}
