using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> races;

        public CarRepository()
        {
            this.races = new List<ICar>();
        }

        public void Add(ICar model)
        {
            this.races.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.races.ToArray();
        }

        public ICar GetByName(string name)
        {
            return this.races.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return this.races.Remove(model);
        }
    }
}
