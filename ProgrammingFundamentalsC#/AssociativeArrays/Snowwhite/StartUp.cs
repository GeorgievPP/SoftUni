using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Snowwhite
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {

                string[] inputInfo = input.Split(" <:> ");

                string name = inputInfo[0];

                string hatColor = inputInfo[1];

                int physics = int.Parse(inputInfo[2]);

                if (!dict.ContainsKey(hatColor))
                {

                    dict[hatColor] = new Dictionary<string, int>();

                    dict[hatColor][name] = physics;

                }

                else
                {

                    if (!dict[hatColor].ContainsKey(name))
                    {

                        dict[hatColor][name] = physics;

                    }

                    else
                    {

                        int currentPhysics = dict[hatColor][name];

                        if (currentPhysics < physics)
                        {

                            dict[hatColor][name] = physics;

                        }

                    }

                }

            }

            dict = dict
                .OrderByDescending(x => x.Value.Count())
                .ToDictionary(a => a.Key, b => b.Value);

            Dictionary<string, int> sortedDict = new Dictionary<string, int>();

            foreach (var kvp in dict)
            {

                foreach (var item in kvp.Value)
                {

                    string currentName = $"({kvp.Key}) {item.Key} <->";

                    sortedDict[currentName] = item.Value;

                }

            }

            sortedDict = sortedDict
                .OrderByDescending(x => x.Value)
                .ToDictionary(a => a.Key, b => b.Value);


            foreach (var kvp in sortedDict)
            {

                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
        }
    }
}
