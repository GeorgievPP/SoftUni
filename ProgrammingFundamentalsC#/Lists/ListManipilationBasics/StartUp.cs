using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipilationBasics
{
    class ListManipilationBasics
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine().Split().ToList ();

            string command = Console.ReadLine();

            while(command != "end")
            {
                string[] action = command.Split();

                if (action[0] == "Add")
                {
                    nums.Add(action[1]);

                }
                else if (action[0] == "Remove")
                {
                    nums.Remove(action[1]);
                }
                else if(action[0] == "RemoveAt")
                {
                    int removeIndex = int.Parse(action[1]);
                    nums.RemoveAt(removeIndex);
                }
                else if( action[0] == "Insert")
                {
                    int insertIndex = int.Parse(action[2]);
                    nums.Insert(insertIndex, action[1]);
                }

                command = Console.ReadLine();
               
            }

            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
