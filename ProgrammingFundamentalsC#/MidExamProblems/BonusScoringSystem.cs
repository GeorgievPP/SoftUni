using System;

namespace BonusScoringSystem
{
    class BonusScoringSystem
    { // 29.02.2020 Group1
        static void Main(string[] args)
        {
            uint countOfStudents = uint.Parse(Console.ReadLine());

            uint countOfLectures = uint.Parse(Console.ReadLine());

            uint initialBonus = uint.Parse(Console.ReadLine());

            double bestStudent = 0.0;

            double totalBonus = 0.0;

            double maxB = 0;



            for (int i = 0; i < countOfStudents; i++)
            {
                double studentAttendance = double.Parse(Console.ReadLine());


                totalBonus = ((studentAttendance * 1.0) / (countOfLectures * 1.0)) * (5 + initialBonus);

                if (maxB <= totalBonus)
                {
                    bestStudent = studentAttendance;

                    maxB = totalBonus;

                }
            }





            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxB)}.");

            Console.WriteLine($"The student has attended {bestStudent} lectures.");


        }
    }
}
