using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> persons;

        public Engine()
        {
            this.products = new List<Product>();
            this.persons = new List<Person>();
        }

        public void Run()
        {
            AddPeople();
            AddProducts();

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = cmdArgs[0];
                string productName = cmdArgs[1];
                try
                {
                    Person person = this.persons.Where(n => n.Name == personName).FirstOrDefault();
                    Product product = this.products.Where(n => n.Name == productName).FirstOrDefault();
                    person.BuyProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach(Person person in this.persons)
            {
                Console.WriteLine(person);
            }

        }

        private void AddPeople()
        {
            string[] personInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for(int i = 0; i < personInput.Length; i++)
            {
                string[] currentPersonInfo = personInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = currentPersonInfo[0];
                decimal money = decimal.Parse(currentPersonInfo[1]);
                Person person = new Person(name, money);
                this.persons.Add(person);
            }
        }

        private void AddProducts()
        {
            string[] productInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for(int i = 0; i < productInfo.Length; i++)
            {
                string[] currentProductInfo = productInfo[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = currentProductInfo[0];
                decimal cost = decimal.Parse(currentProductInfo[1]);
                Product product = new Product(name, cost);
                this.products.Add(product);
            }
        }
    }
}
