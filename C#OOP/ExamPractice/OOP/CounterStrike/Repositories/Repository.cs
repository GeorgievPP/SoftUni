using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models
        {
            get
            {
                return this.models.AsReadOnly();
            }
        }

        public void Add(T model)
        {
            if(model == null)
            {
                throw new ArgumentException(GetNullAddValidationMessage());
            }

            this.models.Add(model);
        }

        public T FindByName(string name)
        {
            return this.models.FirstOrDefault(FindByNameDelegate(name));
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }

        protected abstract string GetNullAddValidationMessage();

        protected abstract Func<T, bool> FindByNameDelegate(string name);
    }
}
