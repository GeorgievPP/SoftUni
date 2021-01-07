using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {

                string[] personArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personArgs[0];

                int age = int.Parse(personArgs[1]);

                Person person = new Person(age, name);

                family.AddMember(person);

            }

            HashSet<Person> result = family.GetAllPeopleAbove30();

            Console.WriteLine(String.Join(Environment.NewLine, result));

        }
    }
}
