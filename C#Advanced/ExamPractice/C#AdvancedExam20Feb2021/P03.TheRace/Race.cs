using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Racer racer)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(racer);
            }

        }

        public bool Remove(string name)
        {
            Racer racer = this.data.Where(n => n.Name == name).FirstOrDefault();
            if(racer != null)
            {
                this.data.Remove(racer);
                return true;
            }

            return false;
        }


        public Racer GetRacer(string name)
        {
            if (this.data.Any())
            {
                Racer racer = this.data.Where(n => n.Name == name).FirstOrDefault();
                return racer;
            }

            return null;

        }

        public Racer GetOldestRacer()
        {
            if (this.data.Any())
            {
                Racer racer = this.data.OrderByDescending(y => y.Age).First();
                return racer;
            }

            return null;
        }

        public Racer GetFastestRacer()
        {
            if (this.data.Any())
            {
                Racer racer = this.data.OrderByDescending(n => n.Car.Speed).First();
                return racer;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach(var racer in this.data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
