using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class CardGame
    {
        static void Main(string[] args)
        {
            List<int> deck1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> deck2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while(true)
            {                                           
                int card1 = deck1[0];
                int card2 = deck2[0];
                if (card1 == card2 )
                {
                    deck1.Remove(card1);
                    deck2.Remove(card2);
             
                }
                else if (card1 > card2)
                {
                    deck2.Remove(card2);
                    deck1.Remove(card1);
                    deck1.Add(card1);
                    deck1.Add(card2);
                }
                else if (card1 < card2)
                {
                    deck2.Remove(card2);
                    deck1.Remove(card1);
                    deck2.Add(card2);
                    deck2.Add(card1);

                }

                if(deck1.Count == 0 || deck2.Count == 0)
                 {
                     break;
                 }     
                 
            }

            if(deck1.Count > deck2.Count)
            {
                int sum = deck1.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = deck2.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }

        }
    }
}
