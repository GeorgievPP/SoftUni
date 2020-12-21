using System;
using System.Collections.Generic;
using System.Linq;

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

            bool noSongs = false;

            while(true)
            {

                string commmand = Console.ReadLine();

                if (noSongs)
                {
                    return;
                }

                if(commmand == "Play")
                {
                    queue.Dequeue();
                }
                else if(commmand == "Show")
                {
                    string[] arr = queue.ToArray();

                    Console.WriteLine(String.Join(", ", arr));
                }
                else
                {
                    string[] cmdArgs = commmand.Split(new char[] {' '}, 2);

                    if(cmdArgs[0] == "Add")
                    {
                        if(!queue.Contains(cmdArgs[1]))
                        {

                            queue.Enqueue(cmdArgs[1]);

                        }
                        else
                        {
                            Console.WriteLine($"{cmdArgs[1]} is already contained!");
                        }
                    }
                }

                if(queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");

                    noSongs = true;
                }

            }

            
        }
    }
}
