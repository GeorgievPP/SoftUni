using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {

                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carInfo[0];

                double fuelAmount = double.Parse(carInfo[1]);

                double fuelConsumptionPerKm = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);

                cars.Add(car);

            }

            string command;

            while((command = Console.ReadLine()) != "End")
            {

                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = cmdArgs[1];

                double amountOfKm = double.Parse(cmdArgs[2]);

                Car currentCar = cars
                    .Where(c => c.Model == model)
                    .ToHashSet()
                    .First();


                currentCar.Drive(model, amountOfKm);

            }

            foreach(Car car in cars)
            {

                Console.WriteLine(car);

            }
        }
    }
}
