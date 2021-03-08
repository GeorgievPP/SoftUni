using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        private int capacity;
        private readonly List<Item> items;

        public Bag(int capacity)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }


        public int Capacity 
        {
            get { return this.capacity; }
            set
            {
                this.capacity = 100;
            }
        }

        public int Load 
            => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items 
            => this.items;

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
             
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if(item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
             
            }

            this.items.Remove(item);

            return item;
        }
    }
}
