
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class HouseParty
    {
        static void Main(string[] args) 
        { // House Party
            List<string> guestsList = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string nameIsGoingOrNot = Console.ReadLine();

                string[] commonSentence = nameIsGoingOrNot.Split().ToArray();

                string name = commonSentence[0];

                if(commonSentence.Length == 3)
                {
                    if(guestsList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guestsList.Add(name);
                    }
                }
                else if (commonSentence.Length == 4)
                {
                    if(guestsList.Contains(name))
                    {
                        guestsList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            foreach(string element in guestsList)
            {
                Console.WriteLine(element);
                
            }
        }
    }
}
