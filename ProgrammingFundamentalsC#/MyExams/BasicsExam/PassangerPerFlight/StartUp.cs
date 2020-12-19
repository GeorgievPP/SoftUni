using System;

namespace PassangersPerFlight
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int aircompanyNum = int.Parse(Console.ReadLine());
            int counterIt = 0;
            double passengerSum = 0.0;
            double passAverage = 0.0;
            double maxSum = int.MinValue;
            string maxAir = "";
            for (int i = 1; i <= aircompanyNum; i++)
            {
                string airName = Console.ReadLine();
                

                while(true)
                {
                    string end = Console.ReadLine();
                    if (end == "Finish")
                    {
                        break;
                    }
                    double passengers = double.Parse(end);
                    counterIt++;
                    passengerSum += passengers;

                }
                passAverage = passengerSum / counterIt;
                Console.WriteLine($"{airName}: {Math.Floor(passAverage)} passengers.");
                if (passAverage > maxSum)
                {
                    maxSum = passAverage;
                    maxAir = airName;
                }

                passengerSum = 0;
                counterIt = 0;
                passAverage = 0;

                
            }
            Console.WriteLine($"{maxAir} has most passengers per flight: {Math.Floor(maxSum)}");
        }
    }
}
