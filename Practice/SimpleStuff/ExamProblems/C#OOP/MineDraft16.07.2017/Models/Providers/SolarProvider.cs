using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models.Providers
{
    public class SolarProvider : Provider
    {
        public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
        {
        }
    }
}
