using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm2._0.Animals
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        private string Breed { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {Weight + FoodEaten * WeightPerFood}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
