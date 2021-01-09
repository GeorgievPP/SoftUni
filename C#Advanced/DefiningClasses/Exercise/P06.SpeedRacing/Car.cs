
using System;

namespace P06.SpeedRacing
{
     public class Car
    {

        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private double travelledDistance;


        public Car (string model, double fuelAmount, double fuelConsumptionPerKm)
        {

            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TravelledDistance = 0;

        }


        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }

        }

        public double FuelAmount
        {

            get
            {
                return this.fuelAmount;
            }
            set
            {
                this.fuelAmount = value;
            }

        }

        public double FuelConsumptionPerKm
        {

            get
            {
                return this.fuelConsumptionPerKm;
            }
            set
            {
                this.fuelConsumptionPerKm = value;
            }

        }


        public double TravelledDistance
        {

            get
            {
                return this.travelledDistance;
            }
            set
            {
                this.travelledDistance = value;
            }

        }



        public void Drive( string model, double amountOfKm)
        {

            double targetLitters = amountOfKm * this.FuelConsumptionPerKm;

            if(targetLitters > this.FuelAmount)
            {

                Console.WriteLine("Insufficient fuel for the drive");

            }

            else
            {

                this.FuelAmount -= targetLitters;

                this.TravelledDistance += amountOfKm;

            }
        }


        public override string ToString()
        {

            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";

        }
    }
}
