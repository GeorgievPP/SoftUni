using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace P06.Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string command;

            while((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string course = input[0];

                string student = input[1];

                if(!dict.ContainsKey(course))
                {
                    dict[course] = new List<string>();

                }
                dict[course].Add(student);

                dict[course].Sort();


            }

            Dictionary<string, List<string>> orderDict = dict

                
                .OrderByDescending(kvp => kvp.Value.Count)
                
                .ToDictionary(a => a.Key, b => b.Value);

           

            foreach(var item in orderDict)
            {

                List<string> studentNames = item.Value;

                Console.WriteLine(item.Key + ": " + orderDict[item.Key].Count);

                foreach(string student in studentNames)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
