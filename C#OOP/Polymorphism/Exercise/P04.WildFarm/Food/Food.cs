using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm2._0.Food
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }

    }
}
