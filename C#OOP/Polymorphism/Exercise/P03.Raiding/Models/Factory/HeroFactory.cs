using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding.Models.Factory
{
    public static class HeroFactory
    {
        public static BaseHero Create( string name, string heroType)
        {
            switch (heroType)
            {
                case nameof(Druid):
                    return new Druid(name);
                case nameof(Paladin):
                    return new Paladin(name);
                case nameof(Rogue):
                    return new Rogue(name);
                case nameof(Warrior):
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
