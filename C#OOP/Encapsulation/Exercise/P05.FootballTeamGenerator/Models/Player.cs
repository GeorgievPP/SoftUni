
using System;

namespace P05.FootballTeamGenerator.Models
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
            get
            {
                return this.name;
            }
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

        public double OverallSkill =>
            this.Stats.AverageStats;

        
    }
}
