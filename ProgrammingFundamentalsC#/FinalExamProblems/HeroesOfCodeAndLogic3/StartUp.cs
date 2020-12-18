using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03.HeroesOfCOdeAndLogic
{
    class StartUp
    {
        static void Main(string[] args)
        {  //100/100

            int  n = int.Parse(Console.ReadLine());

            Dictionary<string, int> heroesHP = new Dictionary<string, int>();

            Dictionary<string, int> heroesMP = new Dictionary<string, int>();

            for(int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(!heroesHP.ContainsKey(heroInfo[0]))
                {

                    heroesHP[heroInfo[0]] = int.Parse(heroInfo[1]);

                    heroesMP[heroInfo[0]] = int.Parse(heroInfo[2]);


                }
            }

            string command;

            while((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                string heroName = input[1];

                if(cmd == "CastSpell")
                {
                    int mana = int.Parse(input[2]);

                    string spellName = input[3];


                    if(mana <= heroesMP[heroName])
                    {
                        heroesMP[heroName] -= mana;

                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroesMP[heroName]} MP!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        continue;
                    }
                }

                else if(cmd == "TakeDamage")
                {
                    int damage = int.Parse(input[2]);

                    string attacker = input[3];

                    if(damage < heroesHP[heroName])
                    {
                        heroesHP[heroName] -= damage;

                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesHP[heroName]} HP left!");
                        continue;
                    }
                    else
                    {
                        heroesHP.Remove(heroName);

                        heroesMP.Remove(heroName);

                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        continue;
                    }
                }
                else if(cmd == "Recharge")
                {
                    int amount = int.Parse(input[2]);

                    if((amount + heroesMP[heroName]) > 200)
                    {
                        amount = 200 - heroesMP[heroName];

                        heroesMP[heroName] = 200;


                    }
                    else
                    {
                        heroesMP[heroName] += amount;
                    }

                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    continue;
                }

                else if(cmd == "Heal")
                {

                    int amount = int.Parse(input[2]);

                    if ((amount + heroesHP[heroName]) > 100)
                    {
                        amount = 100 - heroesHP[heroName];

                        heroesHP[heroName] = 100;


                    }
                    else
                    {
                        heroesHP[heroName] += amount;
                    }

                    Console.WriteLine($"{heroName} healed for {amount} HP!");

                }


            }

            heroesHP = heroesHP
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(s => s.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach(KeyValuePair<string, int> kvp in heroesHP)
            {
                string hero = kvp.Key;

                Console.WriteLine(hero);

                Console.WriteLine($"  HP: {kvp.Value}");

                Console.WriteLine($"  MP: {heroesMP[hero]}");
            }
        }
    }
}
