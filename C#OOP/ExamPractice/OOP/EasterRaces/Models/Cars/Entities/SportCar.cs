using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportCar : Car
    {
        public SportCar(string model, int horsePower) 
            : base(model, horsePower, 3000, 250, 450)
        {
        }
    }
}
