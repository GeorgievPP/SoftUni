using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P0._2SetsOfElement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] nAndM = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = nAndM[0];
            int m = nAndM[1];

            HashSet<int> nSet = ReadSet(n);
            HashSet<int> mSet = ReadSet(m);
            StringBuilder sb = new StringBuilder();

            foreach (var number in nSet)
            {
                if (mSet.Contains(number))
                {
                    sb.Append($"{number} ");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static HashSet<int> ReadSet(int length)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < length; i++)
            {
                int num = int.Parse(Console.ReadLine());
                set.Add(num);
            }

            return set;
        }
    }
}
