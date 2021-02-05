using System;
using System.Collections.Generic;

namespace P06.ParkingLot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = inputInfo[0].ToLower();
                string carNumber = inputInfo[1];

                if (direction == "in")
                {
                    parking.Add(carNumber);
                }

                else
                {
                    parking.Remove(carNumber);
                }

            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
        }
    }
}
