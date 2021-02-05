using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace P02.AverageStudentGrades
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] studentNameAndGrade = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = studentNameAndGrade[0];
                decimal grade = decimal.Parse(studentNameAndGrade[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<decimal>();
                }
                dict[name].Add(grade);
            }

            foreach (var kvp in dict)
            {
                StringBuilder allGrades = new StringBuilder();

                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    allGrades.Append($"{kvp.Value[i]:f2} ");
                }

                Console.WriteLine($"{kvp.Key} -> {allGrades.ToString()}(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
