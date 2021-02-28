using P01.Vehicles.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models.Vehicles
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITIONER_ADDITIONAL_CONSUMPTION = 1.4;
        private AirConditioner airConditioner;

        public Bus(double fuelQuantity, double fuelConsimption, double tankCapacity) : base(fuelQuantity, fuelConsimption, tankCapacity)
        {
            this.airConditioner = AirConditioner.On;
        }

        protected override double AdditionalConsumption =>
            airConditioner == AirConditioner.On ? AIR_CONDITIONER_ADDITIONAL_CONSUMPTION : (double)AirConditioner.Off;

        public void SwitchOnAirConditioner()
        {
            this.airConditioner = AirConditioner.On;
        }

        public void SwitchOffAirConditioner()
        {
            this.airConditioner = AirConditioner.Off;
        }
    }
}
