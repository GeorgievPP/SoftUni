using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm2._0.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

      private double WingSize { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {Weight + FoodEaten * WeightPerFood}, {FoodEaten}]";
        }


    }
}
