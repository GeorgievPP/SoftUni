using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.drivers.GetByName(driverName);
            if(driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            var car = this.cars.GetByName(carModel);
            if(car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.races.GetByName(raceName);
            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var driver = this.drivers.GetByName(driverName);
            if(driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }

            var car1 = this.cars.GetByName(model);
            if(car1 != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            this.cars.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driver = this.drivers.GetByName(driverName);
            if(driver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            var driver1 = new Driver(driverName);
            this.drivers.Add(driver1);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.races.GetByName(name);
            if(race != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            var race1 = new Race(name, laps);
            this.races.Add(race1);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);
            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var race1 = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {race1.First().Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {race1.Skip(1).First().Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {race1.Skip(2).First().Name} is third in {race.Name} race.");

            this.races.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
