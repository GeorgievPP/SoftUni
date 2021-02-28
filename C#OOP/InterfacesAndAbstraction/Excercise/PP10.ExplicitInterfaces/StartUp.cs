using P10.ExplicitInterfaces.Contracts;
using P10.ExplicitInterfaces.Model;
using System;

namespace P10.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                var inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = inputInfo[0];
                string country = inputInfo[1];
                int age = int.Parse(inputInfo[2]);
                Citizen citizen = new Citizen(name, country, age);

                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
