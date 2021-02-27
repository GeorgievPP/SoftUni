using P07.FoodShortage.Contracts;
using P07.FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.FoodShortage
{
    public class StrartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                var inputInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if(inputInfo.Length == 4)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];
                    string birthdate = inputInfo[3];

                    buyers.Add(new Citizen(name, age, id, birthdate));
                }
                else if(inputInfo.Length == 3)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string group = inputInfo[2];

                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                var buyer = buyers.SingleOrDefault(x => x.Name == command);

                if(buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
