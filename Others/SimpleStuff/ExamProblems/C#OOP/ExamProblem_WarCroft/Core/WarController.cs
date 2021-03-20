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
			Character character = null;
			if(args[0] == "Warrior")
            {
				character = new Warrior(args[1]);
            }
			else if(args[0] == "Priest")
            {
				character = new Priest(args[1]);
            }
			if(character == null)
            {
				throw new ArgumentException($"Invalid character type \"{args[0]}\"!");
            }

			this.party.Add(character);

			return $"{args[1]} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;
			if (itemName == "HealthPotion")
			{
				item = new HealthPotion();
			}
			else if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}
			if (item == null)
			{
				throw new ArgumentException($"Invalid item \"{itemName}\"!");
			}

			this.pool.Add(item);

			return $"{itemName} added to pool.";

		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			var character = this.party.FirstOrDefault(x => x.Name == characterName);
			if(character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }

            if (!this.pool.Any())
            {
				throw new InvalidOperationException($"No items left in pool!");
			}

			var item = this.pool.Last();
			this.pool.RemoveAt(this.pool.Count - 1);
			character.Bag.AddItem(item);

			return $"{characterName} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			var character = this.party.FirstOrDefault(x => x.Name == characterName);
			if(character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }
			Item item = null;
			if (itemName == "HealthPotion")
			{
				item = new HealthPotion();
			}
			else if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}
			
			character.UseItem(item);

			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			foreach(var character in this.party.Where(x => x.IsAlive).OrderByDescending(x => x.Health))
            {
				string isAlivve = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {isAlivve}");
            }

			foreach (var character in this.party.Where(x => !(x.IsAlive)).OrderByDescending(x => x.Health))
			{
				string isAlivve = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {isAlivve}");
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			var attacker = (Warrior)this.party.FirstOrDefault(x => x.Name == attackerName);
			if(attacker == null)
            {
				throw new ArgumentException($"Character {attackerName} not found!");
			}

			string receiverName = args[1];
			var receiver = this.party.FirstOrDefault(x => x.Name == receiverName);
			if(receiver == null)
            {
				throw new ArgumentException($"Character {receiverName} not found!");
			}

			if(!attacker.IsAlive || !receiver.IsAlive)
            {
				throw new ArgumentException($"{attacker} cannot attack!");
			}

			attacker.Attack(receiver);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {receiverName} " +
				$"for {attacker.AbilityPoints} hit points! {receiverName} " +
				$"has {receiver.Health}/{receiver.BaseHealth} HP" +
				$" and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			var healer = (Priest)this.party.FirstOrDefault(x => x.Name == healerName);
			if (healer == null)
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}

			string receiverName = args[1];
			var receiver = this.party.FirstOrDefault(x => x.Name == receiverName);
			if (receiver == null)
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}

			if (!healer.IsAlive || !receiver.IsAlive)
			{
				throw new ArgumentException($"{healer} cannot attack!");
			}

			healer.Heal(receiver);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{healer.Name} heals {receiver.Name} " +
				$"for {healer.AbilityPoints}! {receiver.Name}" +
				$" has {receiver.Health} health now!");

			return sb.ToString().TrimEnd();
		}
	}
	
}
