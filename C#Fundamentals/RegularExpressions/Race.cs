using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem02.Race
{
    class Race
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, int> racersDict = new Dictionary<string, int>();

            for (int i = 0; i < participants.Length; i++)
            {
                racersDict[participants[i]] = 0;

            }

            string namePattern = @"[\W\d]";

            string numberPattern = @"[\WA-Za-z]";


            string command;

            while ((command = Console.ReadLine()) != "end of race")
            {
                string name = Regex.Replace(command, namePattern, "");

                string distance = Regex.Replace(command, numberPattern, "");

                int sum = 0;

                foreach(var digit in distance)
                {
                    int currentDigit = int.Parse(digit.ToString());

                    sum += currentDigit;

                }

                if(racersDict.ContainsKey(name))
                {
                    racersDict[name] += sum;

                }



            }

            racersDict = racersDict
                .OrderByDescending(x => x.Value)
                .ToDictionary(a => a.Key, b => b.Value);

            int place = 1;

            foreach(var kvp in racersDict)
            {
                string subst = place == 1 ? "st" : place == 2 ? "nd" : "rd";

                Console.WriteLine($"{place++}{subst} place: {kvp.Key}");

                if(place == 4)
                {
                    break;
                }
            }
        }

    }
}
