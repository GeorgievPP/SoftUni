using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.DragonArmy
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, SortedDictionary<string, int[]>> dict = new Dictionary<string, SortedDictionary<string, int[]>>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string type = input[0];

                string name = input[1];

                int damage = 0;
                
                int health = 0;
                
                int armor = 0;

                damage = input[2] == "null" ? 45 : int.Parse(input[2]);

                health = input[3] == "null" ? 250 : int.Parse(input[3]);

                armor = input[4] == "null" ? 10 : int.Parse(input[4]);

                if(!dict.ContainsKey(type))
                {

                    dict[type] = new SortedDictionary<string, int[]>();

                }

                if(!dict[type].ContainsKey(name))
                {

                    dict[type][name] = new int[3];

                }

                dict[type][name][0] = damage;

                dict[type][name][1] = health;

                dict[type][name][2] = armor;

            }

            foreach( var kvp in dict)
            {

                Console.WriteLine($"{kvp.Key}::({kvp.Value.Select(x => x.Value[0]).Average():F}/{kvp.Value.Select(x => x.Value[1]).Average():f}/{kvp.Value.Select(x => x.Value[2]).Average():f})");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"-{item.Key} -> damage: {item.Value[0]}, health: { item.Value[1]}, armor: {item.Value[2]}");
                }
            }
        }
    }
}
