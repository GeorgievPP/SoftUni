using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.ListOfPredicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isDivisible = true;
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < deviders.Length; j++)
                {
                    if(i % deviders[j] != 0)
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    list.Add(i);
                }

                isDivisible = true;
            }

            Console.WriteLine(String.Join(" ", list));
        }
    }
}
