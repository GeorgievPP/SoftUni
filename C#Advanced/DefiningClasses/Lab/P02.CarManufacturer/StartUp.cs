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

            // Console.WriteLine($"Make: {car.Make} - {car.Model} - {car.Year}");

            car.FuelConsumption = 8;

            car.FuelQuantity = 60;

            car.Drive(4);

            car.Drive(10);

            Console.WriteLine(car.WhoAmI());
            
        }
    }
}
