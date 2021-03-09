using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;


        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders
        {
            get
            {
                return this.foodOrders.AsReadOnly();
            }
        }

        public IReadOnlyCollection<IDrink> DrinkOrders
        {
            get
            {
                return this.drinkOrders.AsReadOnly();
            }
        }

        public int TableNumber
        {
            get { return this.tableNumber; }
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return this.pricePerPerson; }
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved
        {
            get { return this.isReserved; }
            private set
            {
                this.isReserved = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                value = this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(d => d.Price);
                this.price = value;
            }
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
           // this.NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.foodOrders.Sum(x => x.Price) + this.drinkOrders.Sum(x => x.Price);
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
           if(numberOfPeople <= this.Capacity)
            {
                this.IsReserved = true;
                this.NumberOfPeople = numberOfPeople;
            }
        }
    }
}
