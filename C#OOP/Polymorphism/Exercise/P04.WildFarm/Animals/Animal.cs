using System;
using System.Collections.Generic;
using System.Text;
using P04.WildFarm2._0.Food;

namespace P04.WildFarm2._0.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        private string Name { get; set; }

        protected double Weight { get; private set; }

        protected int FoodEaten { get; set; }

        protected abstract double WeightPerFood { get; }

        public abstract string ProduceSound();

        public virtual void EatFoood(Food.Food food)
        {
            ValidateFood(food);
            this.FoodEaten += food.Quantity;
        }

        protected abstract void ValidateFood(Food.Food food);

        protected void Throw(Food.Food food)
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }


    }
}
