﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public class SonicHarvester : Harvester
    {
        private int sonicFactor;

        public SonicHarvester(string id, double oreOutput, double energyRequirement , int sonicFactor) : base(id, oreOutput, energyRequirement)
        {
            this.SonicFactor = sonicFactor;
            this.EnergyRequirement /= SonicFactor;
        }

        public int SonicFactor
        {
            get => this.sonicFactor;
            private set { this.sonicFactor = value; }
        }
    }
}
