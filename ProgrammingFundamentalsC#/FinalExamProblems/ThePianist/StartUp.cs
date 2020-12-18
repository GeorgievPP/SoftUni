using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03.ThePianist
{
    class StartUp
    {
        static void Main(string[] args)
        {  

            Dictionary<string, string> songAuthor = new Dictionary<string, string>();

            Dictionary<string, string> songKey = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] createDict = Console.ReadLine().Split('|');

                if(!songAuthor.ContainsKey(createDict[0]))
                {
                    songAuthor[createDict[0]] = createDict[1];

                    songKey[createDict[0]] = createDict[2];

                }
            }

            string command;

            while((command = Console.ReadLine()) != "Stop")
            {

                string[] input = command.Split('|').ToArray();

                string cmd = input[0];

                string song = input[1];

                if(cmd == "Add")
                {
                    string composer = input[2];

                    string key = input[3];

                    if(!songAuthor.ContainsKey(song))
                    {
                        songAuthor[song] = composer;

                        songKey[song] = key;

                        Console.WriteLine($"{song} by {composer} in {key} added to the collection!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already in the collection!");
                        continue;
                    }
                }
                else if(cmd == "Remove")
                {
                    if(songAuthor.ContainsKey(song))
                    {
                        songAuthor.Remove(song);

                        songKey.Remove(song);

                        Console.WriteLine($"Successfully removed {song}!");
                        continue;

                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {song} does not exist in the collection.");
                        continue;

                    }
                }

                else if(cmd == "ChangeKey")
                {
                    string key = input[2];

                    if (songKey.ContainsKey(song))
                    {
                        songKey[song] = key;

                        Console.WriteLine($"Changed the key of {song} to {key}!");
                        continue;

                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {song} does not exist in the collection.");
                        continue;
                    }
                }

            }

            songAuthor = songAuthor
                .OrderBy(k => k.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach(var kvp in songAuthor)
            {
                string key = kvp.Key;

                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value}, Key: {songKey[key]}");
            }
        }
    }
}
