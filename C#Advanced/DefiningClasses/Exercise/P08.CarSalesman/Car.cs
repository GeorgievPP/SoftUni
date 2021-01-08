

using System.Text;

namespace P08.CarSalesman
{
    public class Car
    {

        private string model;
        private Engine engine;
        private int weight;
        private string color;


        public Car(string model, Engine engine)
        {

            this.Model = model;
            this.Engine = engine;
            this.Weigth = 0;
            this.Color = "n/a";

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

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }


        public int Weigth
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }


        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }

        }


        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine}");

            if (this.Weigth == 0)
            {

                sb.AppendLine($"  Weight: n/a");

            }

            else
            {

                sb.AppendLine($"  Weight: {this.Weigth}");

            }

            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString().Trim();

        }
    }
}
