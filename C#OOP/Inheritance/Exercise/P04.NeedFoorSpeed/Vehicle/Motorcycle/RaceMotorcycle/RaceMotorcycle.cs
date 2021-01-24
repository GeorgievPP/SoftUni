
namespace NeedForSpeed.Vehicle.Motorcycle.RaceMotorcycle
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 8;
        private double fuelConsumption;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
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
