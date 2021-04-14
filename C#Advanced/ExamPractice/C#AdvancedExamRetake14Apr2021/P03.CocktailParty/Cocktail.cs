using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> data;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.data = new List<Ingredient>();

            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel
            => this.data.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if(this.data.Count < this.Capacity && !this.data.Any(x => x.Name == ingredient.Name))
            {
                this.data.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var ingredient = this.data.FirstOrDefault(x => x.Name == name);

            if(ingredient == null)
            {
                return false;
            }

            return this.data.Remove(ingredient);
        }

        public Ingredient FindIngredient(string name)
        {
            var ingredient = this.data.FirstOrDefault(x => x.Name == name);

            if(ingredient == null)
            {
                return null;
            }

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            var ingredient = this.data.OrderByDescending(x => x.Alcohol).FirstOrDefault();

            return ingredient;
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach(var ingredient in this.data)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
