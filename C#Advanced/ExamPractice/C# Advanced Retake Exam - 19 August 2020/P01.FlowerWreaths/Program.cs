using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(liliesInput);

            int[] rosesInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(rosesInput);

            int wreathCount = 0;
            int storedFlowers = 0;
            
            while (true)
            {
                if(!stack.Any() || !queue.Any())
                {
                    break;
                }

                int currentLi = stack.Pop();
                int currentRose = queue.Peek();

                int sum = currentLi + currentRose;

                if(sum == 15)
                {
                    wreathCount++;
                    queue.Dequeue();
                }
                else if(sum > 15)
                {
                    currentLi -= 2;
                    stack.Push(currentLi);
                }
                else
                {
                    queue.Dequeue();
                    storedFlowers += sum;
                }
                
            }

            storedFlowers /= 15;

            if(storedFlowers > 0)
            {
                wreathCount += storedFlowers;
            }

            if(wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                wreathCount = 5 - wreathCount;
                Console.WriteLine($"You didn't make it, you need {wreathCount} wreaths more!");
            }
            
        }
    }
}
