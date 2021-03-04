using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : Repository<IGun>
    {
        protected override Func<IGun, bool> FindByNameDelegate(string name)
        {
            return x => x.Name == name;
        }

        protected override string GetNullAddValidationMessage()
        {
            return "Cannot add null in Gun Repository";
        }
    }
}
