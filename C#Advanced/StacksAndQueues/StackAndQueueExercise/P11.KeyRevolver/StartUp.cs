using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P11.KeyRevolver
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int shoot = 0;
            int bulletCount = 0;
            bool isOpen = false;
            StringBuilder sb = new StringBuilder();

            double priceOfBullet = double.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackBullets = new Stack<int>(bullets);

            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueLocks = new Queue<int>(locks);

            double valueOfInteligence = double.Parse(Console.ReadLine());

            while (true)
            {
                if (!queueLocks.Any())
                {
                    isOpen = true;
                    break;
                }
                if (!stackBullets.Any())
                {
                    break;
                }

                int currentBullet = stackBullets.Pop();
                int currentLock = queueLocks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    queueLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletCount++;
                shoot++;
                if (shoot.Equals(gunBarrelSize) && stackBullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    shoot = 0;
                }
            }

            if (isOpen)
            {
                double bulletCoast = bulletCount * priceOfBullet;
                valueOfInteligence -= bulletCoast;
                sb.Append($"{stackBullets.Count} bullets left. Earned ${valueOfInteligence}");
            }
            else
            {
                sb.Append($"Couldn't get through. Locks left: {queueLocks.Count}");
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
