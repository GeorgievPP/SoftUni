using System;

namespace Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            double courses = Math.Ceiling((numberOfPeople * 1.0) / capacity);

            Console.WriteLine(courses);
        }
    }
}
