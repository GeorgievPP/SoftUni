
namespace NeedForSpeed.Vehicle.Car
{
    public class Car : Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 3;
        private double fuelConsumption;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption
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

        public override void Drive(double kilometers)
        {
            base.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
