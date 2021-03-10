using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
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
            if (attackPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if(attackPlayer is Beginner)
            {
                attackPlayer.Health += 40;
            }

            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += 40;
            }

            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            foreach (var card in enemyPlayer.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            while (true)
            {
                int damagePointOfAttacker = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
                enemyPlayer.TakeDamage(damagePointOfAttacker);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                int damagePointOfEnemy = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
                attackPlayer.TakeDamage(damagePointOfEnemy);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }

        }

       
    }
}
