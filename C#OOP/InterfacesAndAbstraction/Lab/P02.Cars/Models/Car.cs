using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Models
{
    public class Car : ICar
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            string start = $"Engine start";
            return start;
        }

        public string Stop()
        {
            string stop = $"Breaaak!";
            return stop;
        }

       
    }
}
