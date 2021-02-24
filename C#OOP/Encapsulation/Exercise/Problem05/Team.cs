using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem05
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Raiting
        {
            get
            {
                if(this.players.Count == 0)
                {
                    return 0;
                }

                int teamRaiting = (int)Math.Round(this.players.Sum(p => p.OverallSkill) / this.players.Count);
                return teamRaiting;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player player = this.players.Where(p => p.Name == name).FirstOrDefault();
            if(player == null)
            {
                string excMsg = $"Player {name} is not in {this.Name} team.";
                throw new InvalidOperationException(excMsg);
            }

            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Raiting}";
        }


    }
}
