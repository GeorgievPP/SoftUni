using System;
using System.Collections.Generic;
using System.Text;
using VegetableNinja.Interfaces;

namespace VegetableNinja.Models
{
    public delegate void OnMeloLemonMelonEatenHandler(INinja ninja, EventArgs args);

    public class Ninja : GameObject, INinja
    {
        private string name;
        private int power;
        private int stamina;
        private List<IVegetable> collectedVegetables;

        public Ninja(IMatrixPosition position, string name) 
            : base(position, name[0])
        {
            this.Name = name;
            this.Power = 1;
            this.Stamina = 1;
            this.collectedVegetables = new List<IVegetable>();
        }

        public event OnMeloLemonMelonEatenHandler MeloLemonMelonEaten; 
        public string Name
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }

        public int Power
        {
            get => this.power;
            private set
            {
                value = value < 0 ? 0 : value;
                this.power = value;
            }
        }

        public int Stamina
        {
            get => this.stamina;
            private set
            {
                value = value < 0 ? 0 : value;
                this.stamina = value;
            }
        }


        public void Move(IMatrixPosition newPosition)
        {
            if(newPosition == null)
            {
                this.Stamina--;
                return;
            }

            this.Position = newPosition;
            this.Stamina--;
        }

        public void CollectVegetable(IVegetable vegetable)
        {
            this.collectedVegetables.Add(vegetable);
        }

        public void EatVegetable()
        {
            foreach(var vegetable in this.collectedVegetables)
            {
                if (vegetable.CharValue.Equals('*'))
                {
                    if(this.MeloLemonMelonEaten != null)
                    {
                        this.MeloLemonMelonEaten(this, new EventArgs());
                    }
                }

                this.Power += vegetable.PowerBonus;
                this.Stamina += vegetable.StaminaBonus;
            }

            this.collectedVegetables.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("Winner: {0}", this.Name));
            sb.AppendLine(String.Format("Power: {0}", this.Power));
            sb.AppendLine(String.Format("Stamina: {0}", this.Stamina));

            return sb.ToString().TrimEnd(); //TrimEnd()
        }
    }
}
