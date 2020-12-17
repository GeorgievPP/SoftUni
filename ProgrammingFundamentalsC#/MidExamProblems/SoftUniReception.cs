using System;

namespace P01.SoftUniReception
{
    class SoftUniReception
    {  // 05.07.2020
        static void Main(string[] args)
        {
            int employeeFirst = int.Parse(Console.ReadLine());
            int employeeSecond = int.Parse(Console.ReadLine());
            int employeeThird = int.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());

            int employeeCanAnswer = (employeeFirst + employeeSecond + employeeThird);

            int hours = 0;

            while (studentCount > 0)
            {
                studentCount -= employeeCanAnswer;

                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");


        }


    }
}
