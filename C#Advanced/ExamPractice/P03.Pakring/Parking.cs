using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isCarExist = this.data.Exists(c => c.Manufacturer == manufacturer && c.Model == model);

            if (isCarExist)
            {
                this.data.RemoveAll(c => c.Manufacturer == manufacturer && c.Model == model);

            }

            return isCarExist;
        }

        public Car GetLatestCar()
        {
            if (this.data.Any())
            {
                Car car = this.data.OrderByDescending(c => c.Year).First();
                return car;
            }
            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (this.data.Any())
            {
                Car car = this.data.Where(c => c.Manufacturer == manufacturer && c.Model == model).FirstOrDefault();
                return car;
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
