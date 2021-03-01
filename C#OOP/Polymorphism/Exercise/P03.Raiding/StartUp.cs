using P03.Raiding.Models;
using P03.Raiding.Models.Factory;
using System;
using System.Collections.Generic;

namespace P03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            List<BaseHero> heroes = new List<BaseHero>();

           while(counter != n)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = HeroFactory.Create(name, heroType);
                    heroes.Add(hero);
                    counter++;
                   
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int bossHelth = int.Parse(Console.ReadLine());
            int damage = 0;
            
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                damage += hero.Power;
            }

            if(damage >= bossHelth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
