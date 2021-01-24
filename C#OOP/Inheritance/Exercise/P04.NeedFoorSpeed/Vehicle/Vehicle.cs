
namespace NeedForSpeed.Vehicle
{
    public class Vehicle 
    {
        private  const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = this.fuelConsumption;
        }

        public virtual double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = DEFAULT_FUEL_CONSUMPTION;
            }

        }

        public double Fuel
        {
            get
            {
                return this.fuel;
            }
            set
            {
                this.fuel = value;
            }

        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                this.horsePower = value;
            }

        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }



    }
}
