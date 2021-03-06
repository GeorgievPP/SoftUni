﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public class HammerHarvester : Harvester
    {
        public HammerHarvester(string id, double oreOutput, double energyRequirement)
            : base(id, oreOutput, energyRequirement)
        {
            this.OreOutput *= 3;
            this.EnergyRequirement *= 2;
        }
    }
}
