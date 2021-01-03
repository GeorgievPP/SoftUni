using System;
using System.Collections.Generic;
using System.Linq;

namespace MuOnline
{
    class MuOnline
    { // 29.02.2020 Group1
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine().Split('|').ToList();

            int health = 100;

            int bitcoins = 0;

            bool win = true;



            for (int i = 0; i < rooms.Count; i++)
            {
                string[] currentRoom = rooms[i].Split().ToArray();

                string box = currentRoom[0];

                if (box == "potion")
                {
                    int num = int.Parse(currentRoom[1]);


                    if ((num + health) > 100)
                    {
                        int remainder = (num + health) - 100;
                        num -= remainder;

                        health = 100;
                    }
                    else
                    {
                        health += num;

                    }

                    Console.WriteLine($"You healed for {num} hp.");
                    Console.WriteLine($"Current health: {health} hp.");

                }

                else if (box == "chest")
                {
                    int num = int.Parse(currentRoom[1]);

                    bitcoins += num;

                    Console.WriteLine($"You found {num} bitcoins.");
                }

                else
                {
                    int num = int.Parse(currentRoom[1]);

                    health -= num;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {box}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        win = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {box}.");
                    }




                }

            }
            if (win)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }

        }
    }
}
