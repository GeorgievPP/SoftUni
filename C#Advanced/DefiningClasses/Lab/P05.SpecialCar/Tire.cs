
namespace P05.SpecialCars
{
    public class Tire
    {

        private int age;
        private double pressure;


        public Tire(int age, double pressure)
        {

            this.Age = age;
            this.Pressure = pressure;

        }

        public int Age
        {
            get
            {
                return this.Age;
            }
            set
            {
                this.age = value;
            }

        }

        public double Pressure
        {
            get
            {
                return this.pressure;
            }
            set
            {
                this.pressure = value;
            }

        }
    }
}
