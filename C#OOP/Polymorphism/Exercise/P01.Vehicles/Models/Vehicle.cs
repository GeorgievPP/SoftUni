using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsimption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsimption;
        }

        private double FuelQuantity { get;  set; }

        private double FuelConsumption { get; set; }

        protected abstract double AdditionalConsumption { get; }

        public string Drive(double distance)
        {
            double requiredFuel = (this.FuelConsumption + this.AdditionalConsumption) * distance;

            if(requiredFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= requiredFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }


    }
}
