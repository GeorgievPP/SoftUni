using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TheV_Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string vlogger = inputInfo[0];
                string command = inputInfo[1];

                if (command == "joined")
                {
                    if (!dict.ContainsKey(vlogger))
                    {
                        dict[vlogger] = new Dictionary<string, HashSet<string>>();

                        dict[vlogger]["followers"] = new HashSet<string>();
                        dict[vlogger]["following"] = new HashSet<string>();


                        //  dict.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        //  dict[vlogger].Add("followers", new HashSet<string>());
                        //  dict[vlogger].Add("following", new HashSet<string>());
                    }
                }

                else if (command == "followed")
                {
                    string secondVlogger = inputInfo[2];

                    if (dict.ContainsKey(vlogger) && dict.ContainsKey(secondVlogger) && vlogger != secondVlogger)
                    {
                        dict[vlogger]["following"].Add(secondVlogger);
                        dict[secondVlogger]["followers"].Add(vlogger);
                    }

                }

            }

            Console.WriteLine($"The V-Logger has a total of {dict.Count} vloggers in its logs.");

            dict = dict
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(a => a.Key, b => b.Value);

            int number = 1;

            foreach (var vlogger in dict)
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                number++;
            }

        }
    }
}
