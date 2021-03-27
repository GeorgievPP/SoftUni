using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableNinja.Interfaces;

namespace VegetableNinja.Models.Vegetables
{
    public class Vegetable : GameObject, IVegetable
    {
        private int powerBonus;
        private int staminaBonus;
        private int timeToGrow;

        public Vegetable(IMatrixPosition position, char charValue, int powerBonus, int staminaBonus, int timeToGrow)
            : base(position, charValue)
        {
            this.PowerBonus = powerBonus;
            this.StaminaBonus = staminaBonus;
            this.TimeToGrow = timeToGrow;
        }

        public int PowerBonus
        {
            get => this.powerBonus;
            protected set
            {
                this.powerBonus = value;
            }
        }

        public int StaminaBonus
        {
            get => this.staminaBonus;
            protected set
            {
                this.staminaBonus = value;
            }
        }


        public int TimeToGrow
        {
            get => this.timeToGrow;
            protected set
            {
                this.timeToGrow = value;
            }
        }
    }
}
