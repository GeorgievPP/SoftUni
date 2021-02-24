using System;
using System.Collections.Generic;
using System.Text;

namespace Problem05
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stats Stats { get; }

        public double OverallSkill => this.Stats.AverageStat();
    }
}
