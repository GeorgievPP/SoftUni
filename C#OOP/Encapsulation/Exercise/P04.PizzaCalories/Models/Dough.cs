using System;

namespace P04.PizzaCalories.Models
{
    public class Dough
    {
        private double grams;
        private string flourType;
        private string bakingTehnique;
        private double flourTypeCalories;
        private double bakingTehniquesCalories;
        private double totalCalories;
        private string temp;
        private string bakeTemp;

        public Dough(string flourType, string bakingTehniques, double grams)
        {
            this.FlourType = flourType;
            this.BakingTehniques = bakingTehniques;
            this.Grams = grams;

        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                temp = value.ToLower();

                if(temp == "white")
                {
                    this.flourTypeCalories = 1.5;                 
                }
                else if(temp == "wholegrain")
                {
                    this.flourTypeCalories = 1.0;              
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;

            }
        }

        public string BakingTehniques
        {
            get
            {
                return this.bakingTehnique;
            }
            private set
            {
                bakeTemp = value.ToLower();

                if(bakeTemp == "crispy")
                {
                    this.bakingTehniquesCalories = 0.9;
                }
                else if(bakeTemp == "chewy")
                {
                    this.bakingTehniquesCalories = 1.1;
                }
                else if(bakeTemp == "homemade")
                {
                    this.bakingTehniquesCalories = 1.0;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTehnique = value;
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
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.grams = value;
            }

        }

        public double GetCalories()
        {
            this.totalCalories = (2 * this.Grams) * this.flourTypeCalories * this.bakingTehniquesCalories;


            return this.totalCalories;
        }





    }
}
