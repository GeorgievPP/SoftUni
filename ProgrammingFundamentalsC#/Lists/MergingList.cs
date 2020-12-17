using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingList
{
    class MergingList
    {
        static void Main(string[] args)
        {
            List<string> listOne = Console.ReadLine().Split().ToList();

            List<string> listTwo = Console.ReadLine().Split().ToList();

            
            List<string> listResult = new List<string>();

            int lenght = Math.Min(listOne.Count, listTwo.Count);
            int lenghtBig = Math.Max(listOne.Count, listTwo.Count);

            for (int i = 0; i < lenght; i ++)
            {
                listResult.Add(listOne[i]);

                listResult.Add(listTwo[i]);


            }
            if (lenght < listOne.Count)
            {
                for (int i = lenght; i < lenghtBig; i++)
                {
                    listResult.Add(listOne[i]);
                }
            }
            else if (lenght < listTwo.Count)
            {
                for (int i = lenght; i < lenghtBig; i++)
                {
                    listResult.Add(listTwo[i]);
                }
            }
            

            Console.WriteLine(string.Join(" ", listResult));
        }
    }
}
