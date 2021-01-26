using System;

namespace P04.PizzaCalories.Models
{
    public class Topping
    {
        private double toppingCalories;
        private string toppingType;
        private double grams;
        private double totalTopCalories;
        private string temp;

        public Topping(string toppingType, double grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                temp = value.ToLower();

                if(temp == "meat")
                {
                    toppingCalories = 1.2;
                }
                else if(temp == "veggies")
                {
                    toppingCalories = 0.8;
                }
                else if(temp == "cheese")
                {
                    toppingCalories = 1.1;
                }
                else if(temp == "sauce")
                {
                    toppingCalories = 0.9;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.grams = value;
            }
        }

        public double GetTopCalories()
        {
            this.totalTopCalories = (2 * this.Grams) * this.toppingCalories;

            return this.totalTopCalories;
        }
    }
}
