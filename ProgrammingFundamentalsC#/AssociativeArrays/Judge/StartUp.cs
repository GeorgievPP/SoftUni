using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Judge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> usersTotalPoints = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "no more time")
            {

                string[] inputInfo = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string username = inputInfo[0];

                string contest = inputInfo[1];

                int points = int.Parse(inputInfo[2]);

                bool itMustSum = false;

                if (!dict.ContainsKey(contest))
                {

                    dict[contest] = new Dictionary<string, int>();

                    dict[contest][username] = points;

                    itMustSum = true;

                }

                else
                {
                    if (!dict[contest].ContainsKey(username))
                    {

                        dict[contest][username] = points;

                        itMustSum = true;

                    }

                    else
                    {

                        int currentPoints = dict[contest][username];

                        if (currentPoints < points)
                        {

                            dict[contest][username] = points;

                            points -= currentPoints;

                            itMustSum = true;

                        }
                    }

                }

                if (!usersTotalPoints.ContainsKey(username))
                {

                    usersTotalPoints[username] = 0;

                }

                if (itMustSum)
                {

                    usersTotalPoints[username] += points;

                }



            }

            foreach (var kvp in dict)
            {

                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count()} participants");

                int counter = 1;

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {

                    Console.WriteLine($"{counter}. {item.Key} <::> {item.Value}");
                    counter++;

                }
            }

            Console.WriteLine("Individual standings:");

            int counterForUsers = 1;

            foreach (var kvp in usersTotalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{counterForUsers}. {kvp.Key} -> {kvp.Value}");

                counterForUsers++;

            }
        }
    }
}
