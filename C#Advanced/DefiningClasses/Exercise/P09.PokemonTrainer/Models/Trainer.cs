using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P09.PokemonTrainer.Models
{
    public class Trainer
    {
        private string name;
        private int bagesCount;
        private Stack<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.BagesCount = 0;
            this.Pokemons = new Stack<Pokemon>();
        }

        public string Name { get; set; }
        public int BagesCount { get; set; }

        public Stack<Pokemon> Pokemons { get; set; }

        public void AddBages()
        {
            this.BagesCount++;
        }

        public void RemovePokemon()
        {
            if(this.Pokemons.Count > 0 && this.Pokemons.Where(p => p.Health <= 0).FirstOrDefault() != null)
            {
                this.Pokemons = new Stack<Pokemon>(this.Pokemons.Where(p => p.Health > 0));
            }
        }

       
    }
}
