using System;

namespace ForeignLanguages
{
    class ForeigLanguages
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine().ToLower();

            if (country == "usa" || country == "england")
            {
                Console.WriteLine("English");
            }
            else if (country == "spain" || country == "argentina" || country == "mexico")
            {
                Console.WriteLine("Spanish");

            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
