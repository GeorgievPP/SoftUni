using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            switch (aquariumType)
            {
                case nameof(FreshwaterAquarium):
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case nameof(SaltwaterAquarium):
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
            }

            if (aquarium == null)
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            this.aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            switch (decorationType)
            {
                case nameof(Ornament):
                    decoration = new Ornament();
                    break;
                case nameof(Plant):
                    decoration = new Plant();
                    break;
            }

            if (decoration == null)
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            this.decorationRepository.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            switch (fishType)
            {
                case nameof(FreshwaterFish):
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case nameof(SaltwaterFish):
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
            }

            if (fish == null)
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var aquarium = this.aquariums.First(x => x.Name == aquariumName);

            if (fish.GetType().Name == nameof(SaltwaterFish) && aquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);

                return $"Successfully added {fishType} to {aquariumName}.";
            }

            if (fish.GetType().Name == nameof(FreshwaterFish) && aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);

                return $"Successfully added {fishType} to {aquariumName}.";
            }

            return "Water not suitable.";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal total = 0.0m;

            var aquarium = this.aquariums.First(x => x.Name == aquariumName);

            if (aquarium.Fish.Any() || aquarium.Decorations.Any())
            {
                total = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);
            }

            return $"The value of Aquarium {aquariumName} is {total:F2}.";

        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);

            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorationRepository.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var aquarium = this.aquariums.First(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);

            this.decorationRepository.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aqvarium in this.aquariums)
            {
                sb.AppendLine(aqvarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
