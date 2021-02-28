using P01.Vehicles.Models;
using P01.Vehicles.Models.Vehicles;
using System;

namespace P01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            string[] truckInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArgs[1];
                string command = cmdArgs[0];
                double value = double.Parse(cmdArgs[2]);

                switch (type)
                {
                    case nameof(Car):
                        ExecuteCommand(car, command, value);
                        break;
                    case nameof(Truck):
                        ExecuteCommand(truck, command, value);
                        break;
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }
    }
}
