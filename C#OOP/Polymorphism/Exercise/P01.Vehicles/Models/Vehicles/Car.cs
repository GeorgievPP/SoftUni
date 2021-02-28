using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models.Vehicles
{
    public class Car : Vehicle
    {
        private const double ADDITIONAL_CONSUMPTION_PER_KM = 0.9;

        public Car(double fuelQuantity, double fuelConsimption) 
            : base(fuelQuantity, fuelConsimption)
        {
        }

        protected override double AdditionalConsumption => ADDITIONAL_CONSUMPTION_PER_KM;
    }
}
