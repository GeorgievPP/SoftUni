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
                throw new ArgumentException("Player is dead!");
            }

            this.IfPlayerIsBeginner(attackPlayer);
            this.IfPlayerIsBeginner(enemyPlayer);

            attackPlayer = this.BonusHealthPoints(attackPlayer);
            enemyPlayer = this.BonusHealthPoints(enemyPlayer);

            while(true)
            {
                var attackerDamagePoints = attackPlayer.CardRepository.Cards
                                         .Select(x => x.DamagePoints).Sum();

                enemyPlayer.TakeDamage(attackerDamagePoints);
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                var enemyDamagePoints = enemyPlayer.CardRepository.Cards
                    .Select(x => x.DamagePoints).Sum();

              //  var enemyPointsDamage = this.GetTotalDamgePoint(enemyPlayer.CardRepository);

                attackPlayer.TakeDamage(enemyDamagePoints);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

    //   private int GetTotalDamgePoint(ICardRepository cardRepository)
    //   {
    //       int total = 0;
    //
    //       foreach(var card in cardRepository.Cards)
    //       {
    //           total += card.DamagePoints;
    //       }
    //
    //       return total;
    //   }
    //
        private void IfPlayerIsBeginner(IPlayer player)
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

        private IPlayer BonusHealthPoints(IPlayer player)
        {
            player.Health += player.CardRepository.Cards
                .Select(x => x.HealthPoints).Sum();

            return player;
        }
    }
}
