using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {  // 100/100
            string command;

            Dictionary<string, int> cityPop = new Dictionary<string, int>();

            Dictionary<string, int> cityGold = new Dictionary<string, int>();

            while((command = Console.ReadLine()) != "Sail")
            {
                string[] cityInfo = command.Split("||", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(!cityPop.ContainsKey(cityInfo[0]))
                {
                    cityPop[cityInfo[0]] = int.Parse(cityInfo[1]);

                    cityGold[cityInfo[0]] = int.Parse(cityInfo[2]);

                }
                else
                {
                    cityPop[cityInfo[0]] += int.Parse(cityInfo[1]);

                    cityGold[cityInfo[0]] += int.Parse(cityInfo[2]);

                }

            }

            string input;

            while((input = Console.ReadLine()) != "End")
            {
                string[] inputInfo = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = inputInfo[0];

                string town = inputInfo[1];

                if(cmd == "Plunder")
                {
                    int people = int.Parse(inputInfo[2]);

                    int gold = int.Parse(inputInfo[3]);

                    cityPop[town] -= people;

                    cityGold[town] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if(cityPop[town] <= 0 || cityGold[town] <= 0)
                    {
                        cityPop.Remove(town);

                        cityGold.Remove(town);

                        Console.WriteLine($"{town} has been wiped off the map!");

                        continue;
                    }
                }

                else if(cmd == "Prosper")
                {
                    int gold = int.Parse(inputInfo[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");

                        continue;
                    }

                    cityGold[town] += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cityGold[town]} gold.");

                    continue;
                }
            }

            cityGold = cityGold
                .OrderByDescending(x => x.Value)
                .ThenBy(y => y.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine($"Ahoy, Captain! There are {cityGold.Count} wealthy settlements to go to:");

            foreach(var kvp in cityGold)
            {
                string town = kvp.Key;

                Console.WriteLine($"{kvp.Key} -> Population: {cityPop[town]} citizens, Gold: {kvp.Value} kg");
            }
        }
    }
}
