using Minedraft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Factories
{
    public class HarvesterFactory
    {
        public static Harvester Create(List<string> args)
        {
            string type = args[0];

            switch (type)
            {
                case "Sonic":
                    return new SonicHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]), int.Parse(args[4]));
                case "Hammer":
                    return new HammerHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]));
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
