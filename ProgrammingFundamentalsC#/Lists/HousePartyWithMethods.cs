
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class HousePartyWithMethods
    {
        static void Main(string[] args)
        { // House Party With Methods
            List<string> guestsList = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string nameIsOrNotGoing = Console.ReadLine();

                string[] commonSentence = nameIsOrNotGoing.Split().ToArray();

                string nameOfPerson = commonSentence[0];

                if (commonSentence.Length == 3)
                {
                    PeopleIn(guestsList, nameOfPerson);

                }
                else if (commonSentence.Length == 4)
                {
                    PeopleOut(guestsList, nameOfPerson);

                }

            }

            foreach (string element in guestsList)
            {
                Console.WriteLine(element);

            }
        }


        // House Party Method 1
        private static void PeopleOut(List<string> guests, string name)
        {
            if (guests.Contains(name))
            {
                guests.Remove(name);
            }
            else
            {
                Console.WriteLine($"{name} is not in the list!");
            }
        }
         // House Party Method 2

        private static void PeopleIn(List<string> guests, string name)
        {
            if (guests.Contains(name))
            {
                Console.WriteLine($"{name} is already in the list!");
            }
            else
            {
                guests.Add(name);
            }
        }
    }
}
