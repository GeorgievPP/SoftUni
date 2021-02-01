using System;
using System.Linq;
using System.Collections.Generic;

namespace P06.SongsQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] listOfSongs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> queue = new Queue<string>(listOfSongs);

            while (true)
            {
                string commmand = Console.ReadLine();

                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    return;
                }

                if (commmand == "Play")
                {
                    queue.Dequeue();
                }

                else if (commmand == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }

                else
                {
                    string[] cmdArgs = commmand.Split(new char[] { ' ' }, 2);
                    string addCommand = cmdArgs[0];

                    if (addCommand == "Add")
                    {
                        AddSong(queue, cmdArgs);
                    }
                }
            }
        }

        private static void AddSong(Queue<string> queue, string[] cmdArgs)
        {
            string newSong = cmdArgs[1];

            if (!queue.Contains(newSong))
            {
                queue.Enqueue(newSong);
            }
            else
            {
                Console.WriteLine($"{newSong} is already contained!");
            }
        }
    }
}
