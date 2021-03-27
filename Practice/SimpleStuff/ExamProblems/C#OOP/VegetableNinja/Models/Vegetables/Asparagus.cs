using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableNinja.Interfaces;

namespace VegetableNinja.Models.Vegetables
{
    public class Asparagus : Vegetable
    {
        private const char DefaultAsparagusCharValue = 'A';
        private const int DefaultAsparagusPowerBonus = 5;
        private const int DefaultAsparagusStaminaBonus = -5;
        private const int DefaultAsparagusTimeToGrow = 2;

        public Asparagus(IMatrixPosition position) 
            : base(position, DefaultAsparagusCharValue, DefaultAsparagusPowerBonus, DefaultAsparagusStaminaBonus, DefaultAsparagusTimeToGrow)
        {
        }
    }
}
