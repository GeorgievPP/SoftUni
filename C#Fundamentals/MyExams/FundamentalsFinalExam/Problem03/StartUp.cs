using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictOfFr = new Dictionary<string, int>();

            string command;

            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] input = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                string username = input[1];

                if (cmd == "New follower")
                {
                    if (!dictOfFr.ContainsKey(username))
                    {
                        dictOfFr[username] = 0;

                    }

                    continue;
                }

                else if (cmd == "Like")
                {
                    int count = int.Parse(input[2]);

                    if (!dictOfFr.ContainsKey(username))
                    {
                        dictOfFr[username] = count;

                        continue;

                    }
                    else
                    {
                        dictOfFr[username] += count;

                        continue;
                    }


                }

                else if (cmd == "Comment")
                {
                    if (!dictOfFr.ContainsKey(username))
                    {
                        dictOfFr[username] = 1;

                        continue;
                    }

                    else
                    {
                        dictOfFr[username] += 1;

                        continue;

                    }


                }

                else if (cmd == "Blocked")
                {
                    if (dictOfFr.ContainsKey(username))
                    {
                        dictOfFr.Remove(username);

                        continue;

                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");

                        continue;

                    }


                }


            }

            dictOfFr = dictOfFr
                .OrderByDescending(x => x.Value)
                .ThenBy(y => y.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine($"{dictOfFr.Count} followers");

            foreach (KeyValuePair<string, int> kvp in dictOfFr)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
