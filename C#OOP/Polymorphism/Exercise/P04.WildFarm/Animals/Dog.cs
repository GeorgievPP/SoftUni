using P04.WildFarm2._0.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm2._0.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => 0.40;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        protected override void ValidateFood(Food.Food food)
        {
            string type = food.GetType().Name;

            if(type != nameof(Meat))
            {
                Throw(food);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight + FoodEaten * WeightPerFood}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
