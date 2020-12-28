using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.AverageStudentGrades
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = input[0];

                decimal grade = decimal.Parse(input[1]);

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
