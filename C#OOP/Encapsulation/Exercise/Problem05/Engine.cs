using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem05
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] inputInfo = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string command = inputInfo[0];

                    if(command == "Team")
                    {
                        string teamName = inputInfo[1];
                        Team team = new Team(teamName);

                        this.teams.Add(team);
                    }
                    else if(command == "Add")
                    {
                        string teamName = inputInfo[1];
                        string playerName = inputInfo[2];
                        this.ValidateTeamExist(teamName);
                        Team team = this.teams.First(t => t.Name == teamName);
                        Stats stats = this.CreateStats(inputInfo.Skip(3).ToArray());
                        Player player = new Player(playerName, stats);
                        team.AddPlayer(player);
                    }
                    else if(command == "Rating")
                    {
                        string teamName = inputInfo[1];
                        this.ValidateTeamExist(teamName);
                        Team team = this.teams.First(t => t.Name == teamName);
                        Console.WriteLine(team);
                    }
                    else if(command == "Remove")
                    {
                        string teamName = inputInfo[1];
                        string playerName = inputInfo[2];
                        this.ValidateTeamExist(teamName);
                        Team team = this.teams.First(t => t.Name == teamName);
                        team.RemovePlayer(playerName);
                    }
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void ValidateTeamExist(string name)
        {
            if(!this.teams.Any(t => t.Name == name))
            {
                string excMsg = $"Team {name} does not exist.";
                throw new ArgumentException(excMsg);
            }
        }

        private Stats CreateStats(string[] inputInfo)
        {
            int endurance = int.Parse(inputInfo[0]);
            int sprint = int.Parse(inputInfo[1]);
            int driblle = int.Parse(inputInfo[2]);
            int passing = int.Parse(inputInfo[3]);
            int shooting = int.Parse(inputInfo[4]);
            Stats stats = new Stats(endurance, sprint, driblle, passing, shooting);
            return stats;
        }

    }
}
