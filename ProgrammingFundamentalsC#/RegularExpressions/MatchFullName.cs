using System;
using System.Text.RegularExpressions;

namespace Problem01.MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            MatchCollection names = regex.Matches(input);

            foreach(Match name in names)
            {
                Console.Write(name.Value + " ");

            }
        }
    }
}
