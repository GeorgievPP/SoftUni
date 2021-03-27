using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableNinja.Interfaces;

namespace VegetableNinja.Models.Vegetables
{
    public class MeloLemonMelon : Vegetable
    {
        private const char DefaultMeloLemonMelonCharValue = '*';
        private const int DefaultMeloLemonMelonPowerBonus = 0;
        private const int DefaultMeloLemonMelonStaminaBonus = 0;
        private const int DefaultMeloLemonMelonTimeToGrow = -1;

        public MeloLemonMelon(IMatrixPosition position) 
            : base(position, DefaultMeloLemonMelonCharValue, DefaultMeloLemonMelonPowerBonus, DefaultMeloLemonMelonStaminaBonus, DefaultMeloLemonMelonTimeToGrow)
        {
        }
    }
}
