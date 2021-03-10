﻿namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
      // private ICardRepository playerCards;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
           // this.playerCards = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;
            ICardRepository playerCards = new CardRepository();
            if(type == nameof(Beginner))
            {
                player = new Beginner(playerCards, username);
            }
            else if(type == nameof(Advanced))
            {
                player = new Advanced(playerCards, username);
            }

            this.playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";

        }

        public string AddCard(string type, string name)
        {
            ICard card = null;
            if(type == "Magic")
            {
                card = new MagicCard(name);
            }
            else if(type == "Trap")
            {
                card = new TrapCard(name);
            }

            this.cardRepository.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            if(card == null)
            {
                return "Card cannot be null!";
            }
           
            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            var battleField = new BattleField();
            battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var player in this.playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");

                foreach(var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
