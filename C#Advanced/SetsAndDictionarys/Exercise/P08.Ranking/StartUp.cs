using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Ranking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPassword = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> usersDict = new Dictionary<string, Dictionary<string, int>>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputArgs = input
                    .Split(":")
                    .ToArray();
     
                string contest = inputArgs[0];
                string password = inputArgs[1];

                contestPassword[contest] = password;
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {

                string[] inputArgs = input .Split("=>").ToArray();
                
                string contest = inputArgs[0];
                string password = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
                {
                    if (!usersDict.ContainsKey(username))
                    {
                        usersDict[username] = new Dictionary<string, int>();
                        usersDict[username][contest] = points;

                    }

                    else if (!usersDict[username].ContainsKey(contest))
                    {
                        usersDict[username][contest] = points;
                    }

                    else if (usersDict[username].ContainsKey(contest))
                    {
                        if (usersDict[username][contest] < points)
                        {
                            usersDict[username][contest] = points;
                        }
                    }
                }

            }

            Dictionary<string, int> usernameAndPoints = new Dictionary<string, int>();

            foreach (var user in usersDict)
            {
                usernameAndPoints[user.Key] = user.Value.Values.Sum();
            }

            foreach (var username in usernameAndPoints.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"Best candidate is {username.Key} with total {username.Value} points.");
                break;
            }

            Console.WriteLine("Ranking: ");

            foreach (var username in usersDict.OrderBy(x => x.Key))
            {
                Console.WriteLine(username.Key);

                foreach (var contest in username.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
