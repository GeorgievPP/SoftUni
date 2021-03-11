using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if(attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(
                    "Player is dead!");
            }

            this.ModifyBeginnerPlayer(attackPlayer);
            this.ModifyBeginnerPlayer(enemyPlayer);
            attackPlayer = this.BoostPlayer(attackPlayer);
            enemyPlayer = this.BoostPlayer(enemyPlayer);

            while (true)
            {
                var attackerAttackPoints = attackPlayer.CardRepository
                    .Cards
                    .Select(x => x.DamagePoints)
                    .Sum();
                enemyPlayer.TakeDamage(attackerAttackPoints);
                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyAttackPoints = enemyPlayer.CardRepository
                    .Cards
                    .Select(x => x.DamagePoints)
                    .Sum();
                attackPlayer.TakeDamage(enemyAttackPoints);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
            
        }

        private void ModifyBeginnerPlayer(IPlayer player)
        {
            if(player is Beginner)
            {
                player.Health += 40;

                foreach(var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private IPlayer BoostPlayer(IPlayer player)
        {
            player.Health += player.CardRepository
                .Cards
                .Select(x => x.HealthPoints)
                .Sum();

            return player;
        }
       

        private int GetTotalDamagePoints(ICardRepository cardRepository)
        {
            int total = 0;

            foreach(var card in cardRepository.Cards)
            {
                total += card.DamagePoints;
            }

            return total;
        }
    }
}
