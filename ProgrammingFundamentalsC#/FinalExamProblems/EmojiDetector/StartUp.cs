using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem02.EmojiDetector2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\:\:|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);

            long cool = 1;

            bool isCool = false;

            foreach(char ch in input)
            {
                if(Char.IsDigit(ch))
                {
                    string chToSt = ch.ToString();

                    cool *=  int.Parse(chToSt);
                }
            }

            List<string> coolEmojis = new List<string>();

            foreach(Match match in matches)
            {
                string emoji = match.Groups["emoji"].Value;

                long emojiSum = 0;

                foreach(char ch in emoji)
                {


                    emojiSum += ch;
                }

                if(emojiSum > cool)
                {
                    coolEmojis.Add(match.Value.ToString());

                    isCool = true;
                }
            }

            Console.WriteLine($"Cool threshold: {cool}");

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            if (isCool)
            {


                Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));
            }


        }
    }
}
