using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> dictOfPlants = new Dictionary<string, Plant>();

            for(int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string plantName = plantInfo[0];

                int rarity = int.Parse(plantInfo[1]);

                if(!dictOfPlants.ContainsKey(plantName))
                {
                    Plant plant = new Plant(rarity, new List<double>());

                    dictOfPlants[plantName] = plant;

                }

                else
                {
                    dictOfPlants[plantName].Rarity = rarity;
                }
            }

            string command;

            while((command = Console.ReadLine()) != "Exhibition")
            {
                string[] input = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                string[] cmdInfo = input[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = cmdInfo[0];

                if(!dictOfPlants.ContainsKey(name))
                {
                    Console.WriteLine("error");

                    continue;
                }

                if(cmd == "Rate")
                {
                    double raiting = double.Parse(cmdInfo[1]);

                    dictOfPlants[name].Raiting.Add(raiting);


                }

                else if(cmd == "Update")
                {
                    int newRarity = int.Parse(cmdInfo[1]);

                    dictOfPlants[name].Rarity = newRarity;

                }

                else if (cmd == "Reset")
                {
                    dictOfPlants[name].Raiting.Clear();

                }
                else
                {
                    Console.WriteLine("error");

                }
            }

            foreach (var item in dictOfPlants)
            {
                if (!item.Value.Raiting.Any())
                {
                    item.Value.Raiting.Add(0);
                }
            }

            dictOfPlants = dictOfPlants
                .OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.Raiting.Average())
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach(KeyValuePair<string, Plant> kvp in dictOfPlants)
            {
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value.Rarity}; Rating: {kvp.Value.Raiting.Average():f2}");
            }
        }
    }

    public class Plant
    {

        public Plant(int rarity, List<double> raiting)
        {
            Rarity = rarity;

            Raiting = raiting;
        }
        public int Rarity { get; set; } 

        public List<double> Raiting { get; set; } 
    }
}
