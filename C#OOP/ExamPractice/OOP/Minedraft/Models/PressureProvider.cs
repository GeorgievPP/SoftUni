using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public class PressureProvider : Provider
    {
        public PressureProvider(string id, double energyOutput) 
            : base(id, energyOutput)
        {
            this.EnergyOutput *= 1.5;
        }
    }
}
