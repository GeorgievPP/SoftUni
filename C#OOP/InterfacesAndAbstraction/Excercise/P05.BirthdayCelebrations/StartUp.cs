using P04.BorderControl.Contracts;
using P04.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> society = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = inputInfo[0];

                if (type == "Citizen")
                {                  
                    string name = inputInfo[1];
                    int age = int.Parse(inputInfo[2]);
                    string id = inputInfo[3];
                    string birthdate = inputInfo[4];

                    society.Add(new Citizen(name, age, id, birthdate));
                }

                else if( type == "Pet")
                {
                    string name = inputInfo[1];
                    string birthdate = inputInfo[2];

                    society.Add(new Pet(name, birthdate));
                }
            }

            int year = int.Parse(Console.ReadLine());

            society.Where(x => x.Birthdate.Year == year)
                .Select(x => x.Birthdate)
                .ToList()
                .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));

        }
    }
}
