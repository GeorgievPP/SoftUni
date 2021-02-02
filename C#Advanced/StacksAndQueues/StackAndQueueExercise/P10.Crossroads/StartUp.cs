using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P10.Crossroads
{
    class StartUp
    {
        static void Main(string[] args)
        {
            bool crash = false;
            string crashedCar = String.Empty;
            int hitIndex = -1;
            int passedCars = 0;

            int greenLightInterval = int.Parse(Console.ReadLine());
            int freeWindowInterval = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int currGreenLight = greenLightInterval;

                    while (currGreenLight > 0 && cars.Any())
                    {
                        string currentCar = cars.Peek();
                        int carLength = currentCar.Length;
                        currGreenLight -= carLength;

                        if (currGreenLight >= 0)
                        {
                            cars.Dequeue();
                            passedCars++;
                        }

                        else
                        {
                            int left = Math.Abs(currGreenLight);
                            if (left <= freeWindowInterval)
                            {
                                cars.Dequeue();
                                passedCars++;
                            }

                            else
                            {
                                crash = true;
                                crashedCar = currentCar;
                                hitIndex = carLength - left + freeWindowInterval;
                                break;
                            }
                        }
                    }
                }

                else
                {
                    cars.Enqueue(command);
                }

                if (crash)
                {
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();
            if (crash)
            {
                sb.AppendLine("A crash happened!")
                  .AppendLine($"{crashedCar} was hit at {crashedCar[hitIndex]}.");

            }
            else
            {
                sb.AppendLine("Everyone is safe.")
                  .AppendLine($"{passedCars} total cars passed the crossroads.");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
