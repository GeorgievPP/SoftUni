using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if(this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster.Where(p => p.Name == name).FirstOrDefault();
            if(player != null)
            {
                this.roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if(this.roster.Any(p => p.Name == name && p.Rank == "Trial"))
            {
                foreach (var player in roster.Where(n => n.Name == name))
                {
                    player.Rank = "Member";
                    break;
                }
            }
            
        }

        public void DemotePlayer(string name)
        {
            if (this.roster.Any(p => p.Name == name && p.Rank == "Member"))
            {
                foreach (var player in roster.Where(n => n.Name == name))
                {
                    player.Rank = "Trial";
                    break;
                }
            }

        }


        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kickedClass = this.roster.Where(p => p.Class == @class).ToArray();
            this.roster = this.roster.Where(p => p.Class != @class).ToList();
            if (kickedClass.Any())
            {
                return kickedClass;
            }

            return null;
        }

        public string Report()
        {
            if (this.roster.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Players in the guild: {this.Name}");
                foreach (var player in roster)
                {
                    sb.AppendLine(player.ToString());
                }

                return sb.ToString().TrimEnd();
            }

            return null;
        }
    }
}
