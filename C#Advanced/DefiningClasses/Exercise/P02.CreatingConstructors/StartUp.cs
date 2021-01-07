using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string name = "Pesho";

            int age = 24;

            Person pesho = new Person(age, name);

            Console.WriteLine($"{pesho.Name} -> {pesho.Age}");
        }
    }
}
