using System;
using System.Collections.Generic;
using System.Text;

namespace Problem05
{
    public class Stats
    {
        private const int STAT_MIN_VALUE = 0;
        private const int STAT_MAX_VALUE = 100;
        private const double STAT_COUNT = 5;

        private int endurance;
        private int sprint;
        private int dribble;
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
            get => this.endurance;
            private set
            {
                ValidateSkills(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateSkills(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Driblle
        {
            get => this.dribble;
            private set
            {
                ValidateSkills(value, nameof(this.Driblle));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateSkills(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateSkills(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double AverageStat()
        {
            double average = (this.Endurance + this.Sprint + this.Driblle + this.Passing + this.Shooting) / STAT_COUNT;
            return average;
        }

        private void ValidateSkills(int value, string skill) 
        {
            if(value < STAT_MIN_VALUE || value > STAT_MAX_VALUE)
            {
                string expMsg = $"{skill} should be between {STAT_MIN_VALUE} and {STAT_MAX_VALUE}.";
                throw new ArgumentException(expMsg);
            }

        }
    }
}
