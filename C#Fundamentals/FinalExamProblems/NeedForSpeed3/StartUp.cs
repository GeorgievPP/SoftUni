using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> carMilege = new Dictionary<string, int>();

            Dictionary<string, int> carFuel = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] carinfo = Console.ReadLine().Split('|').ToArray();

                carMilege[carinfo[0]] = int.Parse(carinfo[1]);

                carFuel[carinfo[0]] = int.Parse(carinfo[2]);

            }

            string command;
            while((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command.Split(" : ").ToArray();

                string cmd = cmdArgs[0];

                string car = cmdArgs[1];

                if(cmd == "Drive")
                {
                    int milege = int.Parse(cmdArgs[2]);

                    int fuel = int.Parse(cmdArgs[3]);

                    if(carFuel[car] < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");

                        continue;
                    }
                    else
                    {
                        carMilege[car] += milege;

                        carFuel[car] -= fuel;

                        Console.WriteLine($"{car} driven for {milege} kilometers. {fuel} liters of fuel consumed.");

                        

                    }

                    if(carMilege[car] >= 100000)
                    {
                        carMilege.Remove(car);

                        carFuel.Remove(car);

                        Console.WriteLine($"Time to sell the {car}!");
                        continue;
                    }


                }

                else if(cmd == "Refuel")
                {

                    int fuel = int.Parse(cmdArgs[2]);

                    if(carFuel[car] + fuel > 75 )
                    {
                        fuel = 75 - carFuel[car];
                    }

                    carFuel[car] += fuel;

                    Console.WriteLine($"{car} refueled with {fuel} liters");

                    continue;

                }

                else if( cmd == "Revert")
                {
                    int milege = int.Parse(cmdArgs[2]);

                    if(carMilege[car] - milege > 10000)
                    {
                        carMilege[car] -= milege;

                        Console.WriteLine($"{car} mileage decreased by {milege} kilometers");

                        continue;

                    }
                    else
                    {
                        carMilege[car] = 10000;
                    }
                }

            }

            carMilege = carMilege
                .OrderByDescending(x => x.Value)
                .ThenBy(y => y.Key)
                .ToDictionary(a => a.Key, b => b.Value);


            foreach(var kvp in carMilege)
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value} kms, Fuel in the tank: {carFuel[kvp.Key]} lt.");
            }
        }
    }

    
}
