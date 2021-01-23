
using System;

namespace P05.FootballTeamGenerator.Models
{
    public class Stats
    {
        private int STAT_MIN_VALUE = 0;
        private int STAT_MAX_VALUE = 100;
        private const double STATS_COUNT = 5;

        private int endurance;
        private int sprint;
        private int driblle;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int driblle, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Driblle = driblle;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                VlidateStat(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                VlidateStat(value, nameof(this.Sprint));

                this.sprint = value;
            }
        }

        public int Driblle
        {
            get
            {
                return this.driblle;
            }
            private set
            {
                VlidateStat(value, nameof(this.Driblle));

                this.driblle = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                VlidateStat(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                VlidateStat(value, nameof(this.Shooting));

                this.shooting = value;
            }
        }

        public double AverageStats =>
            (this.Endurance + this.Sprint + this.Driblle + this.Passing + this.Shooting) / STATS_COUNT;

        private void VlidateStat(int value, string statName)
        {
            if (value < STAT_MIN_VALUE || value > STAT_MAX_VALUE)
            {
                string excMsg = $"{statName} should be between {STAT_MIN_VALUE} and {STAT_MAX_VALUE}.";

                throw new ArgumentException(excMsg);
            }
        }
    }
}
