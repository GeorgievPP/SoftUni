using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.PredicateParty_
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> guest = Console.ReadLine().Split().ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = command.Split(' ').ToArray();
                string cmdType = cmdArgs[0];
                string[] predicateArgs = cmdArgs.Skip(1).ToArray();

                Predicate<string> predicate = GetPredicate(predicateArgs);

                if (cmdType == "Remove")
                {
                    guest.RemoveAll(predicate);
                }

                else if (cmdType == "Double")
                {
                    for (int i = 0; i < guest.Count; i++)
                    {
                        string currentGuest = guest[i];

                        if (predicate(currentGuest))
                        {
                            guest.Insert(i + 1, currentGuest);
                            i++;
                        }
                    }
                }
            }

            if (guest.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            else
            {
                Console.WriteLine($"{String.Join(", ", guest)} are going to the party!");
            }

        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            Predicate<string> predicate = null;
            string prType = predicateArgs[0];
            string prArg = predicateArgs[1];

            if (prType == "StartsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.StartsWith(prArg);
                });
            }

            else if (prType == "EndsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.EndsWith(prArg);
                });
            }

            else if (prType == "Length")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(prArg);
                });
            }

            return predicate;
        }
    }
}
