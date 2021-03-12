using Minedraft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Factories
{
    public class ProviderFactory
    {
        public static Provider Create(List<string> args)
        {
            string type = args[0];

            switch (type)
            {
                case "Solar":
                    return new SolarProvider(args[1], double.Parse(args[2]));
                case "Pressure":
                    return new PressureProvider(args[1], double.Parse(args[2]));
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
