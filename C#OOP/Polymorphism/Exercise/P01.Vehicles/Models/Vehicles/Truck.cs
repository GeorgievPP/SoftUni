using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const double ADDITIONAL_CONSUMPTION_PER_KM = 1.6;
        private const double REFUELING_COEFFICIENT = 0.95;

        public Truck(double fuelQuantity, double fuelConsimption) 
            : base(fuelQuantity, fuelConsimption)
        {
        }

        protected override double AdditionalConsumption => ADDITIONAL_CONSUMPTION_PER_KM;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * REFUELING_COEFFICIENT);
        }
    }
}
