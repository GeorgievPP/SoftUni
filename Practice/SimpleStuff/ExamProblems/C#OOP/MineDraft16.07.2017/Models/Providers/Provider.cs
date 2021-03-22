using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models.Providers
{
    public abstract class Provider : Item
    {
        private double energyOutput;

        protected Provider(string id, double energyOutput)
            : base(id)
        {
            this.EnergyOutput = energyOutput;
        }

        public double EnergyOutput
        {
            get => this.energyOutput;
            protected set
            {
                if (value <= 0 || value > 10000)
                {
                    throw new ArgumentException(nameof(this.EnergyOutput));
                }

                this.energyOutput = value;
            }
        }
    }
}
