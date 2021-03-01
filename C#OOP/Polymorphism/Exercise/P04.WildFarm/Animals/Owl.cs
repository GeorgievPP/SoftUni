using P04.WildFarm2._0.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm2._0.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerFood => 0.25;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        protected override void ValidateFood(Food.Food food)
        {
           if(food.GetType().Name != nameof(Meat))
            {
                this.Throw(food);
            }
        }
    }
}
