using System;

namespace Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            PrintGrade(input);
        }
        static void PrintGrade (double grade)
        {
            string printGrade = "";
            if (grade >= 2.00 && grade <= 2.99)
            {
                printGrade = "Fail";
            }
            else if (grade >= 3.00 && grade <= 3.49)
            {
                printGrade = "Poor";
            }
            else if (grade >= 3.50 && grade <= 4.49)
            {
                printGrade = "Good";
            }
            else if (grade >= 4.50 && grade <= 5.49)
            {
                printGrade = "Very good";
            }
            else if (grade >= 5.50 && grade <= 6.00)
            {
                printGrade = "Excellent";
            }

            Console.WriteLine(printGrade);
        }
    }
}
