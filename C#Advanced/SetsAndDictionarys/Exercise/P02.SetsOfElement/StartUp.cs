using System;
using System.Collections.Generic;
using System.Linq;

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

            int length = n + m;

            HashSet<int> nSet = new HashSet<int>();

            HashSet<int> mSet = new HashSet<int>();

            FillSets(n, length, nSet, mSet);

            foreach (var number in nSet)
            {

                if (mSet.Contains(number))
                {

                    Console.Write(number + " ");

                }
            }
        }

        private static void FillSets(int n, int length, HashSet<int> nSet, HashSet<int> mSet)
        {
            for (int i = 0; i < length; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i < n)
                {

                    nSet.Add(num);

                }

                else
                {

                    mSet.Add(num);

                }
            }
        }
    }
}
