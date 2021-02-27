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
            List<IIdentifable> society = new List<IIdentifable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo.Length == 2)
                {
                    string model = inputInfo[0];
                    string id = inputInfo[1];
                    IRobot robot = new Robot(model, id);

                    society.Add(robot);
                }

                else if (inputInfo.Length == 3)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];
                    ICitizen citizen = new Citizen(name, age, id);

                    society.Add(citizen);
                }
            }

            string lastDigits = Console.ReadLine();

            society.Where(x => x.Id.EndsWith(lastDigits))
                .Select(x => x.Id).ToList()
                .ForEach(Console.WriteLine);

        }
    }
}
