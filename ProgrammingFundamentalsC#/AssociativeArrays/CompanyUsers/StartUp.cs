using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)

        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string command;

            while((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string company = input[0];

                string code = input[1];

                if(!dict.ContainsKey(company))
                {
                    dict[company] = new List<string>();

                }

                if(!dict[company].Contains(code))
                {
                    dict[company].Add(code);
                }
            }

            Dictionary<string, List<string>> newDict = dict
                .OrderBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach(var kvp in newDict)
            {
                List<string> list = kvp.Value;

                Console.WriteLine(kvp.Key);

                foreach(string id in list)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
