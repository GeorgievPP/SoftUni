using System;
using System.Collections.Generic;

namespace P07.SoftUniParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> vipSet = new HashSet<string>();
            HashSet<string> regularSet = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    while (input != "END")
                    {
                        input = Console.ReadLine();

                        if (char.IsDigit(input[0]))
                        {
                            vipSet.Remove(input);
                        }

                        else
                        {
                            regularSet.Remove(input);
                        }

                    }

                    break;
                }

                else
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipSet.Add(input);
                    }

                    else
                    {
                        regularSet.Add(input);
                    }

                }

            }

            Console.WriteLine(vipSet.Count + regularSet.Count);

            if (vipSet.Count > 0)
            {
                foreach (var number in vipSet)
                {
                    Console.WriteLine(number);
                }

            }

            if (regularSet.Count > 0)
            {
                foreach (var number in regularSet)
                {
                    Console.WriteLine(number);
                }

            }

        }
    }
}
