using System;
using System.Collections.Generic;

namespace P04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if(this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double Calories()
        {
            double sum = 0;

            sum += this.dough.GetCalories();

            this.toppings.ForEach(t => sum += t.GetTopCalories());

            return sum;

        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories():f2} Calories.";
        }





    }
}
