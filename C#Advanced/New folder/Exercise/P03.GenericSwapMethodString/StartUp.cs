using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            for (int i = 0; i < n; i++)
            {

                string name =Console.ReadLine();

                names.Add(name);

            }
                Box<string> box = new Box<string>(names);

            int[] indexToSwap = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            box.Swap(box.Values, indexToSwap[0], indexToSwap[1]);

            Console.WriteLine(box);

        }
    }
}
