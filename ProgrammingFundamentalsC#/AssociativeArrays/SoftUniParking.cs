using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace P05.SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                if(cmd == "register")
                {
                    string user = input[1];

                    string plate = input[2];

                    if(!dict.ContainsKey(user))
                    {
                        dict[user] = plate;

                        Console.WriteLine($"{user} registered {plate} successfully");

                    }

                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {dict[user]}");

                    }

                }
                else if(cmd == "unregister")
                {
                    string user = input[1];

                    if(!dict.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");

                    }
                    else
                    {
                        dict.Remove(user);

                        Console.WriteLine($"{user} unregistered successfully");

                    }
                }

                
            }

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
