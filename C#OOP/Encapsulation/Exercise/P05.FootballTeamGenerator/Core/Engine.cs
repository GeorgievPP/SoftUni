
using System;
using System.Collections.Generic;
using System.Linq;
using P05.FootballTeamGenerator.Models;

namespace P05.FootballTeamGenerator.Core
{
    public class Engine
    {

        private List<Models.Team> teams;

        public Engine()
        {
            this.teams = new List<Models.Team>();
        }

        public void Run()
        {


            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = command.Split(';', StringSplitOptions.None).ToArray();
                    string cmdType = cmdArgs[0];

                    if (cmdType == "Team")
                    {
                        string teamName = cmdArgs[1];

                        Team team = new Team(teamName);

                        this.teams.Add(team);
                    }

                    else if (cmdType == "Add")
                    {
                        string teamName = cmdArgs[1];
                        string playerName = cmdArgs[2];

                        this.ValidateTeamExist(teamName);

                        Team team = this.teams.First(t => t.Name == teamName);

                        Stats stats = this.CreateStats(cmdArgs.Skip(3).ToArray());

                        Player player = new Player(playerName, stats);

                        team.AddPlayer(player);
                    }

                    else if (cmdType == "Remove")
                    {
                        string teamName = cmdArgs[1];
                        string playerName = cmdArgs[2];

                        this.ValidateTeamExist(teamName);

                        Team team = this.teams.First(t => t.Name == teamName);

                        team.RemovePlayer(playerName);
                    }

                    else if (cmdType == "Rating")
                    {
                        string teamName = cmdArgs[1];

                        this.ValidateTeamExist(teamName);

                        Team team = this.teams.First(t => t.Name == teamName);

                        Console.WriteLine(team);
                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

        }

        private void ValidateTeamExist(string name)
        {
            if (!this.teams.Any(t => t.Name == name))
            {
                string excMes = $"Team {name} does not exist.";

                throw new ArgumentException(excMes);
            }
        }

        private Models.Stats CreateStats(string[] cmdArgs)
        {
            int endurance = int.Parse(cmdArgs[0]);
            int sprint = int.Parse(cmdArgs[1]);
            int dribble = int.Parse(cmdArgs[2]);
            int passing = int.Parse(cmdArgs[3]);
            int shooting = int.Parse(cmdArgs[4]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            return stats;
        }
    }
}
