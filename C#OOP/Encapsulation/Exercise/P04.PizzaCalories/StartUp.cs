using System;
using P04.PizzaCalories.Models;

namespace P04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {

                string[] pizzaInput = Console.ReadLine().Split();
                string pizzaNeme = pizzaInput[1];
                Pizza pizza = new Pizza(pizzaNeme);

                string[] doughInput = Console.ReadLine().Split();
                string flourType = doughInput[1];
                string bakingTehniques = doughInput[2];
                double grams = double.Parse(doughInput[3]);
                pizza.Dough = new Dough(flourType, bakingTehniques, grams);
          
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = command.Split();
                    string toppingType = toppingInput[1];
                    double toppingGrams = double.Parse(toppingInput[2]);
                    pizza.AddTopping(new Topping(toppingType, toppingGrams));
                }

                Console.WriteLine(pizza);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
