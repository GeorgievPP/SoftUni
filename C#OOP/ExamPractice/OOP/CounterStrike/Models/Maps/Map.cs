using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrosists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrosists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            SeparateTeams(players);

            while(true)
            {
                AttackTeam(terrorists, counterTerrosists);
                AttackTeam(counterTerrosists, terrorists);

                if (!IsTeamAlive(counterTerrosists))
                {
                    return "Terrorist wins!";
                }
                if (!IsTeamAlive(terrorists))
                {
                    return "Counter Terrorist wins!";
                }
            }
        }

        private bool IsTeamAlive(List<IPlayer> players)
        {
            return players.Any(p => p.IsAlive);
        }

        private void AttackTeam(List<IPlayer> attackingTeam, List<IPlayer> defendingTeam)
        {
            foreach (var attacker in attackingTeam)
            {
               // if (!attacker.IsAlive) continue;

                foreach(var defender in defendingTeam)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

        private void SeparateTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    this.terrorists.Add(player);
                }
                else if (player is CounterTerrorist)
                {
                    this.counterTerrosists.Add(player);
                }
            }
        }
    }
}
