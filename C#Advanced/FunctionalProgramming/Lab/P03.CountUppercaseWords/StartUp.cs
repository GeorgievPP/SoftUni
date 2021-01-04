using System;
using System.Linq;

namespace P03.CountUppercaseWords
{
    class StartUp
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(str => str[0] == str.ToUpper()[0])
                .ToArray();

            // Func<string, bool> upperChecker = str => str[0] == str.ToString()[0];
            //
            // string[] input2 = Console.ReadLine()
            //     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //     .Where(upperChecker)
            //     .ToArray();

            Console.WriteLine(String.Join(Environment.NewLine, input));
        }
    }
}
