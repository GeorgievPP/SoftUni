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
            string type = args[0];


            if (type != nameof(Warrior) && type != nameof(Priest))
            {
                throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            Character character = null;
            switch (type)
            {
                case nameof(Warrior):
                    character = new Warrior(name);
                    break;
                case nameof(Priest):
                    character = new Priest(name);
                    break;

            }

            this.party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];
            if (name != nameof(HealthPotion) && name != nameof(FirePotion))
            {
                throw new ArgumentException($"Invalid item \"{ name }\"!");
            }

            Item item = null;

            if (name == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else if (name == nameof(FirePotion))
            {
                item = new FirePotion();
            }


            this.pool.Add(item);

            return $"{name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];
            var character = this.party.FirstOrDefault(x => x.Name == name);
            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            Item item = this.pool.Last();

            character.EnsureAlive();
            character.Bag.AddItem(item);

            return $"{name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];

            var character = this.party.FirstOrDefault(x => x.Name == charName);
            if (character == null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(h => h.Health))
            {
                string status = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string targetName = args[1];

            var attacker = this.party.FirstOrDefault(x => x.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            var target = this.party.FirstOrDefault(x => x.Name == targetName);

            if (target == null)
            {
                throw new ArgumentException($"Character {targetName} not found!");
            }

            if (!(attacker is IAttacker))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            ((IAttacker)attacker).Attack(target);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attacker.Name} attacks {target.Name} for {attacker.AbilityPoints} hit points! {target.Name} has {target.Health}/{target.BaseHealth} HP and {target.Armor}/{target.BaseArmor} AP left!");

            if (!target.IsAlive)
            {
                sb.AppendLine($"{target.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = this.party.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            var receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (!(healer is IHealer))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            ((IHealer)healer).Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
