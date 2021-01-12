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

            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {

                double element = double.Parse(Console.ReadLine());

                elements.Add(element);

            }


            Box<double> box = new Box<double>(elements);

            double elementToCompare = double.Parse(Console.ReadLine());

            int countOfGreaterElements = box.CountGreaterElement(elements, elementToCompare);

            Console.WriteLine(countOfGreaterElements);

        }
    }
}
