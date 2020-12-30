using System;
using System.Collections.Generic;

namespace P01.UniqueUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {

            HashSet<string> uniqueUsernames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string username = Console.ReadLine();

                uniqueUsernames.Add(username);

            }

            Console.WriteLine(String.Join(Environment.NewLine, uniqueUsernames));
        }
    }
}
