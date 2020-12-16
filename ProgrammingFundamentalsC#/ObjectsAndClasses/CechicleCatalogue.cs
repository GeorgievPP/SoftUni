using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem06.VechicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;

            List<Vechicle> catalogue = new List<Vechicle>();

            while((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();

                string vechicleType = input[0];
                
              

                Vechicle vechicle = new Vechicle(vechicleType.ToLower(), input[1], input[2].ToLower(), int.Parse(input[3]));

                catalogue.Add(vechicle);


            }

            string secondCmd;

            while((secondCmd = Console.ReadLine()) != "Close the Catalogue")
            {
                string modelType = secondCmd;

                Vechicle printCar = catalogue.First(x => x.Name == modelType);

                Console.WriteLine(printCar);

                
            }

            List<Vechicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();

            List<Vechicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

            double totalCarHp = onlyCars.Sum(x => x.HorsePower);

            double totalTruckHp = onlyTrucks.Sum(x => x.HorsePower);

            double avgCarHp = 0.00;

            double avgTruckHp = 0.00;

            if(onlyCars.Count > 0)
            {
                avgCarHp = totalCarHp / onlyCars.Count;


            }
            if( onlyTrucks.Count > 0)
            {
                avgTruckHp = totalTruckHp / onlyTrucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarHp:f2}.");

            Console.WriteLine($"Trucks have average horsepower of: {avgTruckHp:f2}.");

        }
    }

    public class Vechicle
    {

        public Vechicle(string type, string name, string color, int horsePow)
        {
            Type = type;

            Name = name;

            Color = color;

            HorsePower = horsePow;


        }
        public string Name { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");

            sb.AppendLine($"Model: {Name}");

            sb.AppendLine($"Color: {Color}");

            sb.AppendLine($"Horsepower: {HorsePower}");



            return sb.ToString().TrimEnd();
        }
    }

}
