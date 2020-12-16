using System;

namespace ommonElements
{
    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] arrFirst = Console.ReadLine().Split();
            string[] arrSecond = Console.ReadLine().Split();

            foreach(string elementInSecondArr in arrSecond )
            {
                foreach(string elementInFirs in arrFirst)
                {
                    if (elementInSecondArr == elementInFirs)
                    {
                        Console.Write(elementInSecondArr + " ");
                    }
                }
            }
        }
    }
}
