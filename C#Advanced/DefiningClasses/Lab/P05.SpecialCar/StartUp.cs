using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.SpecialCars
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Tire[]> tires = new List<Tire[]>();

            string command;

            while ((command = Console.ReadLine()) != "No more tires")
            {

                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                Tire tires1 = new Tire(int.Parse(input[0]), double.Parse(input[1]));

                Tire tires2 = new Tire(int.Parse(input[2]), double.Parse(input[3]));

                Tire tires3 = new Tire(int.Parse(input[4]), double.Parse(input[5]));

                Tire tires4 = new Tire(int.Parse(input[6]), double.Parse(input[7]));

                tires.Add(new Tire[] { tires1, tires2, tires3, tires4 });

            }

            List<Engine> engines = new List<Engine>();

            while ((command = Console.ReadLine()) != "Engines done")
            {

                string[] input = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Engine newEngine = new Engine(int.Parse(input[0]), double.Parse(input[1]));

                engines.Add(newEngine);

            }


            List<Car> cars = new List<Car>();

            while ((command = Console.ReadLine()) != "Show special")
            {

                string[] input = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string make = input[0];

                string model = input[1];

                int year = int.Parse(input[2]);

                double fuelQuantity = double.Parse(input[3]);

                double fuelConsumption = double.Parse(input[4]);

                Engine engine = engines[int.Parse(input[5])];

                Tire[] tire = tires[int.Parse(input[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tire);

                cars.Add(car);

            }

            cars = cars
                .Where(x => x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.Tires.Sum(y => y.Pressure) >= 9
                && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();

            double distance = 20;

            foreach (Car car in cars)
            {

                car.Drive(distance);

                Console.WriteLine(car);

            }

        }
    }
}
