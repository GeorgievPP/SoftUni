using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Engine> engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string engineModel = engineInfo[0];

                int power = int.Parse(engineInfo[1]);

                Engine engine = new Engine(engineModel, power);

                if (engineInfo.Length == 3)
                {

                    int displacement;

                    if (int.TryParse(engineInfo[2], out displacement))
                    {

                        engine.Displacement = displacement;

                    }

                    else
                    {

                        engine.Efficiency = engineInfo[2];

                    }

                }

                else if (engineInfo.Length == 4)
                {

                    int displacement = int.Parse(engineInfo[2]);

                    string efficiency = engineInfo[3];

                    engine.Displacement = displacement;

                    engine.Efficiency = efficiency;

                }

                engines.Add(engine);

            }

            List<Car> cars = new List<Car>();

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {

                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carModel = carInfo[0];

                string engineModel = carInfo[1];

                Engine engine = engines
                    .FirstOrDefault(engines => engines.Model == engineModel);

                Car car = new Car(carModel, engine);

                if (carInfo.Length == 3)
                {

                    int weight;

                    if (int.TryParse(carInfo[2], out weight))
                    {

                        car.Weigth = weight;

                    }

                    else
                    {

                        car.Color = carInfo[2];

                    }

                }

                else if (carInfo.Length == 4)
                {

                    int weight = int.Parse(carInfo[2]);

                    string color = carInfo[3];

                    car.Weigth = weight;

                    car.Color = color;

                }

                cars.Add(car);

            }

            foreach (Car car in cars)
            {

                Console.WriteLine(car);

            }

        }
    }
}
