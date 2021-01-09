using System;

namespace P05.DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {

            string dateOne = Console.ReadLine();

            string dateTwo = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.GetDifferenceOfTwoDates(dateOne, dateTwo));
        }
    }
}
