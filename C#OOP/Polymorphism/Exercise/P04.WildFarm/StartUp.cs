using P04.WildFarm2._0.Animals;
using P04.WildFarm2._0.Factories;
using System;
using System.Collections.Generic;

namespace P04.WildFarm2._0
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                Animal animal = AnimalFactory.Create(command.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());

                Food.Food food = FoodFactory.Create(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

                try
                {
                    animal.EatFoood(food);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
