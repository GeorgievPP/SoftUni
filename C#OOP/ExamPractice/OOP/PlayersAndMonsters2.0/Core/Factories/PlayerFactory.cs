using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {

        public IPlayer CreatePlayer(string type, string username)
        {
            switch (type)
            {
                case "Beginner":
                    return new Beginner(new CardRepository(), username);
                case "Advanced":
                    return new Advanced(new CardRepository(), username);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
