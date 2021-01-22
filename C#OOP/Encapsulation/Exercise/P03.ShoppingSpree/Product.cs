
using System;

namespace P03.ShoppingSpree
{
    public class Product
    {

        private const decimal CONST_MIN_VALUE = 0m;
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.GlobalConstants.InvalidNameExeptionMessage);
                }

                this.name = value;
            }

        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if(value < CONST_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.GlobalConstants.InvalidMoneyExeptionMessage);
                }

                this.cost = value;
            }

        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
