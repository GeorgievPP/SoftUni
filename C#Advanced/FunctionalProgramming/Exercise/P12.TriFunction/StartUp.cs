using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));
            string targetName = null;

            foreach(var name in list)
            {
                int sum = 0;
                foreach(var ch in name)
                {
                    sum += ch;
                }

                if(sum >= n)
                {
                    targetName = name;
                }
            }

            if(targetName != null)
            {
                Console.WriteLine(targetName);
            }
        }
    }
}
