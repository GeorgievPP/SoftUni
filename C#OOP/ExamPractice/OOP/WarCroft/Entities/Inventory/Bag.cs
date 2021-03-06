﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private List<Item> items;

        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }


        public int Capacity 
        {
            get { return this.capacity; }
            set
            {
                this.capacity = value;
            }
        }

        public int Load 
            => this.Items.Sum(x => x.Weight);

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
            if (this.Items.Count == 0)
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
