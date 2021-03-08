using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private Bag bag;



        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }


        public double BaseHealth
        {
            get { return this.baseHealth; }
            private set
            {
                this.baseHealth = value;
            }
        }

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value >= 0 && value <= this.baseHealth)
                {
                    this.health = value;
                }
            }
        }


        public double BaseArmor
        {
            get { return this.baseArmor; }
            private set
            {
                this.baseArmor = value;
            }
        }

        public double Armor
        {
            get { return this.armor; }
            private set
            {
                if (value >= 0)
                {
                    this.armor = value;
                }
            }
        }


        public double AbilityPoints { get; private set; }

        public Bag Bag
        {
            get { return this.bag; }
            private set
            {
                this.bag = value;
            }
        }


        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor >= hitPoints)
                {
                    this.Armor -= hitPoints;
                    return;
                }
                else
                {
                    if (this.Armor != 0)
                    {
                        hitPoints -= this.Armor;
                        this.Armor = 0;
                    }

                    if (this.Health > hitPoints)
                    {
                        this.Health -= hitPoints;
                    }
                    else
                    {
                        this.Health = 0;
                        this.IsAlive = false;
                    }
                }
            }
            else
            {
                this.EnsureAlive();
            }
        }

        public void UseItem(Item item)
        {


            if (item.GetType().Name == "HealthPotion")
            {
                var item2 = new HealthPotion();
                item2.AffectCharacter(this);
                this.Bag.GetItem(item2.GetType().Name);
            }
            else if (item.GetType().Name == "FirePotion")
            {
                var item2 = new FirePotion();
                item2.AffectCharacter(this);
                this.Bag.GetItem(item2.GetType().Name);
            }


        }

    }
}