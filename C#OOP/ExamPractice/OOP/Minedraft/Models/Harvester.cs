using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public abstract class Harvester : Item
    {
        private double oreOutput;
        private double energyRequirement;

        protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
        {
            this.OreOutput = oreOutput;
            this.EnergyRequirement = energyRequirement;
        }

        public double OreOutput
        {
            get => this.oreOutput;
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException(nameof(OreOutput));
                }

                this.oreOutput = value;
            }
        }

        public double EnergyRequirement
        {
            get => this.energyRequirement;
            protected set
            {
                if(value < 0 || value > 20000)
                {
                    throw new ArgumentException(nameof(EnergyRequirement));
                }

                this.energyRequirement = value;
            }
        }
    }
}
