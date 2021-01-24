
namespace NeedForSpeed.Vehicle.Car.SportCar
{
    public class SportCar : Car
    {

        private const double DEFAULT_FUEL_CONSUMPTION = 10;
        private double fuelConsumption;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
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
