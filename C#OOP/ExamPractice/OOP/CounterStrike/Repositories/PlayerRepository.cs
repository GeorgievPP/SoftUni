using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : Repository<IPlayer>
    {
        protected override Func<IPlayer, bool> FindByNameDelegate(string name)
        {
            return x => x.Username == name;
        }

        protected override string GetNullAddValidationMessage()
        {
            return "Cannot add null in Player Repository";
        }
    }
}
