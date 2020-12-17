﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem04.StarEnigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            string pattern = @"@(?<planet>[A-Z][a-z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-!:>]*!(?<attack>A|D)![^@\-!:>]*->(?<soldiers>\d+)";

            List<string> attackedPlanets = new List<string>();

            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i ++)
            {
                string encryptedMessage = Console.ReadLine();

                int specialNumber = SpecialLettersCount(encryptedMessage);

                string decryptedMessage = DecryptMessage(encryptedMessage, specialNumber);

                Match match = Regex.Match(decryptedMessage, pattern);

                if(match.Success)
                {
                    string planetName = match.Groups["planet"].Value;

                    string attackType = match.Groups["attack"].Value;

                    if(attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }

            }

            PrintOutputForPlanets(attackedPlanets, "Attacked");

            PrintOutputForPlanets(destroyedPlanets, "Destroyed");
        }

        private static int SpecialLettersCount (string message)
        {
            char[] specialLetters = new char[] { 's', 't', 'a', 'r' };

            int specialLettersCount = 0;

            for(int i = 0; i < message.Length; i ++)
            {
                char currentChar = message[i];

                if(specialLetters.Contains(Char.ToLower(currentChar)))
                {
                    specialLettersCount++;

                }
            }

            return specialLettersCount;

        }

        private static string DecryptMessage(string encrypted, int key)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < encrypted.Length; i++)
            {

                char currentChar = encrypted[i];

                char decryptedChar = (char)(currentChar - key);

                sb.Append(decryptedChar);

            }

            return sb.ToString();

        }

        private static void PrintOutputForPlanets(List<string> planets, string attackType)
        {
            Console.WriteLine($"{attackType} planets: {planets.Count}");

            foreach(string planet in planets.OrderBy(pln => pln))
            {
                Console.WriteLine($"-> {planet}");

            }

        }
    }
}
