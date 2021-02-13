using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> list = input.Where(n => n.Length <= length).ToList();

            Console.WriteLine(String.Join(Environment.NewLine, list));          
        }
    }
}
