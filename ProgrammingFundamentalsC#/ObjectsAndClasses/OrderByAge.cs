using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;


            List<Person> listOfPersons = new List<Person>();


            while((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();

                Person person = new Person(input[0], input[1], int.Parse(input[2]));

                listOfPersons.Add(person);

            }

            listOfPersons = listOfPersons
                .OrderBy(x => x.Age)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, listOfPersons));
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public string Number { get; set; } 

        public int Age { get; set; }

        public Person (string name, string number, int age)
        {
            Name = name;

            Number = number;

            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {Number} is {Age} years old.";
;
        }
    }
}
