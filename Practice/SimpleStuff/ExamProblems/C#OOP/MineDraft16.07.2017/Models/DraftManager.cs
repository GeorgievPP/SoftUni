using Minedraft.Enums;
using Minedraft.Factories;
using Minedraft.Models;
using Minedraft.Models.Harvesters;
using Minedraft.Models.Providers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minedraft
{
    public class DraftManager
    {
        private Dictionary<string, Harvester> harvesters;
        private Dictionary<string, Provider> providers;
        private double energyStored;
        private double oreMined;
        private WorkingMode mode;

        public DraftManager()
        {
            this.harvesters = new Dictionary<string, Harvester>();
            this.providers = new Dictionary<string, Provider>();
            this.energyStored = 0;
            this.oreMined = 0;
            this.mode = WorkingMode.Full;
        }


        public string RegisterHarvester(List<string> arguments)
        {
            try
            {
                var newHarvester = HarvesterFactory.Create(arguments);
                this.harvesters.Add(newHarvester.Id, newHarvester);

                return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
            }
            catch (ArgumentException ae)
            {
                return $"Harvester is not registered, because of it's {ae.Message}";
            }
        }
        public string RegisterProvider(List<string> arguments)
        {
            try
            {
                var newProvider = ProviderFactory.Create(arguments);
                this.providers.Add(newProvider.Id, newProvider);

                return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
            }
            catch(ArgumentException ae)
            {
                return $"Provider is not registered, because of it's {ae.Message}"; 
            }
        }
       public string Day()
        {
            double newEnergy = this.providers.Values.Sum(p => p.EnergyOutput);
            this.energyStored += newEnergy;

            double energyCoef = mode == WorkingMode.Full ? 1 : mode == WorkingMode.Half ? 0.6 : 0;
            double oreOutputCoef = mode == WorkingMode.Full ? 1 : mode == WorkingMode.Half ? 0.5 : 0;

            double requiredEnergy = this.harvesters.Values.Sum(x => x.EnergyRequirement) * energyCoef;

            double oreGained = 0;

            if(requiredEnergy <= energyStored)
            {
                energyStored -= requiredEnergy;
                oreGained = this.harvesters.Values.Sum(x => x.OreOutput) * oreOutputCoef;
                oreMined += oreGained;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("A day has passed.")
                .AppendLine($"Energy Provided: {newEnergy}")
                .Append($"Plumbus Ore Mined: {oreGained}");

            return sb.ToString().TrimEnd();
        }
        public string Mode(List<string> arguments)
        {
            this.mode = (WorkingMode)Enum.Parse(typeof(WorkingMode), arguments[0]);
            return $"Successfully changed working mode to {this.mode.ToString()} Mode";
        }
        public string Check(List<string> arguments)
        {
            StringBuilder sb = new StringBuilder();

            string id = arguments[0];

            Item item;

            if (this.harvesters.ContainsKey(id))
            {
                item = harvesters[id];

                var harvester = (Harvester)item;
                string type = item is SonicHarvester ? "Sonic" : "Hammer";

                sb.AppendLine($"{type} Harvester - {harvester.Id}");
                sb.AppendLine($"Ore Output: {harvester.OreOutput}");
                sb.AppendLine($"Energy Requirement: {harvester.EnergyRequirement}");

                return sb.ToString().TrimEnd();
            }

            if (this.providers.ContainsKey(id))
            {
                item = providers[id];

                var provider = (Provider)item;
                string type = item is PressureProvider ? "Pressure" : "Solar";

                sb.AppendLine($"{type} Provider - {id}");
                sb.AppendLine($"Energy Output: {provider.EnergyOutput}");

                return sb.ToString().TrimEnd();
            }

            return $"No element found with id - {id}";
        }
       public string ShutDown()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"System Shutdown")
                .AppendLine($"Total Energy Stored: {energyStored}")
                .AppendLine($"Total Mined Plumbus Ore: {oreMined}");

            return sb.ToString().TrimEnd();
        }

    }
}
