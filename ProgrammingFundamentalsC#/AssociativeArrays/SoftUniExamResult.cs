using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.SoftUniExamResult
{
    class SoftUniExamResult
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();

            Dictionary<string, int> dictCount = new Dictionary<string, int>();

            string command;

            while((command = Console.ReadLine()) != "exam finished")
            {
                string[] input = command.Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = input[0];

                string course = input[1];
                           
                if(course == "banned")
                {
                    dict.Remove(name);
                    continue;
                }
                else
                {
                    if(!dictCount.ContainsKey(course))
                    {
                        dictCount[course] = 0;
                    }

                    dictCount[course]++;

                }

                if(input.Length > 2)
                {
                    int points = int.Parse(input[2]);

                    if (!dict.ContainsKey(name))
                    {
                        dict[name] = new List<int>();

                    }

                    dict[name].Add(points);

                }
 
            }

            Dictionary<string, List<int>> newDict = dict
                .OrderByDescending(kvp => kvp.Value.Max())
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine("Results:");

            foreach(var kvp in newDict)
            {
                List<int> list = kvp.Value;

                int t = list.Max();

                Console.WriteLine($"{kvp.Key} | {t}");

            }

            Console.WriteLine("Submissions:");

            Dictionary<string, int> newCountDict = dictCount
                 .OrderByDescending(kvp => kvp.Value)
                 .ThenBy(kvp => kvp.Key)
                 .ToDictionary(a => a.Key, b => b.Value);

            foreach(var kvp in newCountDict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
