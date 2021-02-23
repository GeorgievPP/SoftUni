using System;
using System.Collections.Generic;
using System.Text;

namespace Problem03
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;


        public Person (string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
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
                    throw new Exception("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return this.bag;
            }
        }


        public void BuyProduct(Product product)
        {
            if(this.Money < product.Cost)
            {
                throw new Exception($"{this.Name} can't afford {product.Name}");
            }

            this.Money -= product.Cost;
            this.bag.Add(product);
        }

        public override string ToString()
        {
            string products = this.bag.Count > 0 ? String.Join(", ", bag) : "Nothing bought";

            return $"{this.Name} - {products}";
        }
    }
}
