using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MOBAChallenger
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, Dictionary<string, int>> levels = new Dictionary<string, Dictionary<string, int>>();

            string input;

            while((input = Console.ReadLine()) != "Season end")
            {

                if(input.Contains(" -> "))
                {

                    string[] inputInfo = input.Split(" -> ");

                    string name = inputInfo[0];

                    string position = inputInfo[1];

                    int points = int.Parse(inputInfo[2]);

                    if(!players.ContainsKey(name))
                    {

                        players[name] = new Dictionary<string, int>();

                        players[name][position] = points;

                    }

                    else
                    {

                        if(!players[name].ContainsKey(position))
                        {

                            players[name][position] = points;

                        }

                        else
                        {

                            int currentPoints = players[name][position];

                            if(currentPoints < points)
                            {

                                players[name][position] = points;

                            }

                        }

                    }

                    if(!levels.ContainsKey(position))
                    {

                        levels[position] = new Dictionary<string, int>();

                        levels[position][name] = points;

                    }

                    else
                    {

                        if(!levels[position].ContainsKey(name))
                        {

                            levels[position][name] = points;

                        }

                        else
                        {
                            int currentPoints = levels[position][name];

                            if(currentPoints < points)
                            {

                                levels[position][name] = points;

                            }

                        }

                    }

                }

                else if(input.Contains(" vs "))
                {

                    string[] battleInfo = input.Split(" vs ");

                    string firstPlayer = battleInfo[0];

                    string secondPlayer = battleInfo[1];

                    foreach(var kvp in levels)
                    {

                        if(kvp.Value.ContainsKey(firstPlayer) && kvp.Value.ContainsKey(secondPlayer))
                        {

                            int pointsOfFirstPlayer = levels[kvp.Key][firstPlayer];

                            int pointsOfSecondPlayer = levels[kvp.Key][secondPlayer];

                            if( pointsOfFirstPlayer > pointsOfSecondPlayer)
                            {

                                players[secondPlayer].Remove(kvp.Key);

                            }

                            else if(pointsOfFirstPlayer < pointsOfSecondPlayer)
                            {

                                players[firstPlayer].Remove(kvp.Key);
                            }

                        }

                    }

                }

            }

            players = players
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in players)
            {

                if( kvp.Value.Count != 0)
                {

                    Console.WriteLine($"{kvp.Key}: {kvp.Value.Sum(x => x.Value)} skill");

                }
                
                foreach(var item in kvp.Value
                    .Where(x => x.Value > 0)
                    .OrderByDescending(x => x.Value)
                    .ThenBy(y => y.Key))
                {

                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
                    
            }

        }
    }
}
