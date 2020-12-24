using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P07.Studentacademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for(int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                double grade = double.Parse(Console.ReadLine());


                if(!dict.ContainsKey(name))
                {
                    dict[name] = new List<double>();

                }

                dict[name].Add(grade);

                

            }

            Dictionary<string, List<double>> newDict = dict
                .OrderByDescending(kvp => kvp.Value.Average())
                .ToDictionary(a => a.Key, b => b.Value);

            foreach(var kvp in newDict)
            {
                double grade = kvp.Value.Average();

                if(grade >= 4.50)
                {
                    Console.WriteLine($"{kvp.Key} -> {grade:f2}");
                }

                
            }
                 
        }
    }
}
