using System;

namespace P01.CounterStrike
{
    class CounterStrike
    { // 07 April 2020
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            bool lose = false;

            int count = 0;

            while ( command != "End of battle")
            {
                int distance = int.Parse(command);

                if(distance > energy)
                {
                    lose = true;
                    break;

                }

                energy -= distance;

                count++;

                if(count % 3 == 0)
                {
                    energy += count;

                }
                command = Console.ReadLine();

            }
            if(lose)
            {
                Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
            }
        }
        
        
    }
}
