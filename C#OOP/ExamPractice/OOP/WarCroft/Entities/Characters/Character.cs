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
        private double abilityPoints;
        private Bag bag;
        private bool isAlive;



        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.IsAlive = true;
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
            private set
            {
                this.health = value;
              
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
                 this.armor = value;
            }
        }


        public double AbilityPoints
        {
            get { return this.abilityPoints; }
            private set { this.abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return this.bag; }
            private set
            {
                this.bag = value;
            }
        }


        public bool IsAlive
        {
            get { return isAlive; }
            private set { isAlive = value; }
        }

        internal void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if(this.Armor < hitPoints)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;

                if(this.Health <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }

                return;
            }

            this.Armor -= hitPoints;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        internal void IncreaseHealth(double points)
        {
            this.Health = Math.Min(BaseHealth, Health + points);
        }

        internal void ReduceHealth(int amount)
        {
            this.Health = Math.Max(0, this.Health - amount);

            if (Health <= 0)
            {
                this.IsAlive = false;
            }
        }

    }
}