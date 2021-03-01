using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm2._0.Animals
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get; private set; }
    }
}
