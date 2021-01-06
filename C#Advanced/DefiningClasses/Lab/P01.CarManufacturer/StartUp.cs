using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Car car = new Car();

            car.Make = "Nissan";

            car.Model = "X-Trail";

            car.Year = 2005;

            Console.WriteLine($"Make: {car.Make} - {car.Model} - {car.Year}");
        }
    }
}
