using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P02.HelloFrance
{
    class HelloFrance
    {
        static void Main(string[] args)
        {
            // 100% 10.03.2019.G1

            List<string> list = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            double budget = double.Parse(Console.ReadLine());

            List<double> newPrices = new List<double>();

            double firstBudget = budget;

            for(int i = 0; i < list.Count; i ++)
            {

                string[] arr = list[i].Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = arr[0];

                double price = double.Parse(arr[1]);

                if(type == "Clothes" && (price <= budget && price <= 50)) 
                {
                    budget -= price;

                    price += (price * 0.4);

                    newPrices.Add(price);

                }
                else if(type == "Shoes" && (price <= budget && price <= 35))
                {
                    budget -= price;

                    price += (price * 0.4);

                    newPrices.Add(price);
                }
                else if(type == "Accessories" && (price <= budget && price <= 20.50))
                {
                    budget -= price;

                    price += (price * 0.4);

                    newPrices.Add(price);
                }

            }

            double sum = newPrices.Sum();

            double profit = (budget + sum) - firstBudget;

           for (int i = 0; i < newPrices.Count; i ++)
            {
                Console.Write($"{newPrices[i]:f2} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Profit: {profit:f2}");

            if ((profit + firstBudget) >= 150)
            {
                Console.WriteLine("Hello, France!");

            }
            else
            {
                Console.WriteLine("Time to go.");
            }


        }
    }
}
