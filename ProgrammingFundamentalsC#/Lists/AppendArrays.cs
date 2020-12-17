using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries).ToList();

            list.Reverse();

            List<string> result = new List<string>();

            foreach(var currentItem in list)
            {
                string[] numbers = currentItem.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                foreach(var numbersToAdd in numbers)
                {
                    result.Add(numbersToAdd);

                }

               
            }

            Console.WriteLine(string.Join(" ", result));
        } 
    }
}
