using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));
            List<string> filters = new List<string>();

            string input;
            while((input = Console.ReadLine()) != "Print")
            {
                var commands = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Add filter")
                {
                    filters.Add(commands[1] + " " + commands[2]);
                }
                else if (commands[0] == "Remove filter")
                {
                    filters.Remove(commands[1] + " " + commands[2]);
                }

            }

            foreach( var filter in filters)
            {
                var commands = filter.Split();
                if (commands[0] == "Starts")
                {
                    guests = guests.Where(p => !p.StartsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Ends")
                {
                    guests = guests.Where(p => !p.EndsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Length")
                {
                    guests = guests.Where(p => p.Length != int.Parse(commands[1])).ToList();
                }
                else if (commands[0] == "Contains")
                {
                    guests = guests.Where(p => !p.Contains(commands[1])).ToList();
                }

            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
    }
}
