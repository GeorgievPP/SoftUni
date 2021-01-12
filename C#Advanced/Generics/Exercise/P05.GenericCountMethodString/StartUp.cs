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

            List<string> elements = new List<string>();

            for (int i = 0; i < n; i++)
            {

                string element = Console.ReadLine();

                elements.Add(element);

            }


            Box<string> box = new Box<string>(elements);

            string elementToCompare = Console.ReadLine();

            int countOfGreaterElements = box.CountGreaterElement(elements, elementToCompare);

            Console.WriteLine(countOfGreaterElements);

        }
    }
}
