using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>();

            Dictionary<string, long> productQuantityes = new Dictionary<string, long>();

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = productArgs[0];

                decimal price = decimal.Parse(productArgs[1]);

                int quantity = int.Parse(productArgs[2]);

                if (!productQuantityes.ContainsKey(name))
                {
                    productQuantityes[name] = 0;

                    productPrices[name] = 0m;

                }

                productQuantityes[name] += quantity;

                productPrices[name] = price;

            }

            foreach (KeyValuePair<string, decimal> kvp in productPrices)
            {
                string name = kvp.Key;

                decimal price = kvp.Value;

                long qty = productQuantityes[name];

                decimal totalPrice = price * qty;

                Console.WriteLine($"{name} -> {totalPrice:f2}");
            }
        }
    }
}
