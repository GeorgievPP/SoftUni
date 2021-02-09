using System;
using System.Collections.Generic;
using System.Linq;

using P09.PokemonTrainer.Models;

namespace P09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<Trainer> trainers = new Queue<Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string element = inputArgs[2];
                int health = int.Parse(inputArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                var currentTrainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();

                if(currentTrainer == null)
                {
                    currentTrainer = new Trainer(trainerName);
                    currentTrainer.Pokemons.Push(pokemon);
                    trainers.Enqueue(currentTrainer);
                }

                else
                {
                    currentTrainer.Pokemons.Push(pokemon);
                }
               
            }

            string command;
            while((command = Console.ReadLine().Trim()) != "End")
            {
                foreach(var trainer in trainers)
                {
                    if(trainer.Pokemons.Where(p => p.Element == command).FirstOrDefault() == null)
                    {
                        foreach(var pokemon in trainer.Pokemons)
                        {
                            pokemon.ReduceHealth();
                        }

                        trainer.RemovePokemon();
                    }

                    else
                    {
                        trainer.AddBages();
                    }

                }

            }


            Console.WriteLine(String.Join(Environment.NewLine, trainers
                .OrderByDescending(t => t.BagesCount)
                .Select(t => $"{t.Name} {t.BagesCount} {t.Pokemons.Count}")));

        }
    }
}
