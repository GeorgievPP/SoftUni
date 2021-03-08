using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> pool;
		
		public WarController()
		{
			this.party = new List<Character>();
			this.pool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string name = args[1];
			string post = args[0];

			Character character = null;

			if(post == "Warrior")
            {
				character = new Warrior(name);
            }
			else if(post == "Priest")
            {
				character = new Priest(name);
            }

			if(character == null)
            {
				throw new ArgumentException($"Invalid character type \"{post}\"!");
			}

			this.party.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string name = args[0];

			Item item = null;

			if(name == "HealthPotion")
            {
				item = new HealthPotion();
            }
			else if( name == "FirePotion")
            {
				item = new FirePotion();
            }

			if(item == null)
            {
				throw new ArgumentException($"Invalid item \"{ name }\"!");
            }

			this.pool.Add(item);

			return $"{name} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string name = args[0];
			Character character = this.party.FirstOrDefault(x => x.Name == name);
			if(character == null)
            {
				throw new ArgumentException($"Character {name} not found!");
            }

            if (!this.pool.Any())
            {
				throw new InvalidOperationException("No items left in pool!");
            }
			Item item = this.pool.Last();

			character.Bag.AddItem(item);

			return $"{name} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string charName = args[0];
			string itemName = args[1];

			Character character = this.party.FirstOrDefault(x => x.Name == charName);

			if(character == null)
            {
				throw new ArgumentException($"Character {charName} not found!");
            }
			Item item = character.Bag.GetItem(itemName);

			character.UseItem(item);

			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			foreach(var character in this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(h => h.Health))
            {
				string status = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attacker = args[0];
			string target = args[1];

			var character = (Warrior) this.party.FirstOrDefault(x => x.Name == attacker);

			if (character == null)
			{
				throw new ArgumentException($"Character {attacker} not found!");
			}

			Character targetCharacter = this.party.FirstOrDefault(x => x.Name == target);

			if (targetCharacter == null)
			{
				throw new ArgumentException($"Character {target} not found!");
			}

            if (!targetCharacter.IsAlive || !character.IsAlive)
            {
				throw new ArgumentException($"{attacker} cannot attack!");
            }

			character.Attack(targetCharacter);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{ character.Name} attacks {targetCharacter.Name} for { character.AbilityPoints} hit points! { targetCharacter.Name} has { targetCharacter.Health}/{ targetCharacter.BaseHealth} HP and { targetCharacter.Armor}/{ targetCharacter.BaseArmor} AP left!");

            if (!targetCharacter.IsAlive)
            {
				sb.AppendLine($"{targetCharacter.Name} is dead!");
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			var character = (Priest) this.party.FirstOrDefault(x => x.Name == healerName);

			if (character == null)
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}

			Character targetCharacter = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

			if (targetCharacter == null)
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}

			if(!character.IsAlive || !targetCharacter.IsAlive)
            {
				throw new ArgumentException($"{healerName} cannot heal!");
            }

			character.Heal(targetCharacter);
			
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{character.Name} heals {targetCharacter.Name} for {character.AbilityPoints}! {targetCharacter.Name} has {targetCharacter.Health} health now!");

			return sb.ToString().TrimEnd();
		}
	}
}
