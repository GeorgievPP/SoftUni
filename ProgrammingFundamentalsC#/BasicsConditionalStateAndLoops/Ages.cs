using System;
using System.Threading;

namespace Ages
{
    class Ages
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string bounder = "";

            if (age >= 0 && age <=2 )
            {
                bounder = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                bounder = "child";
            }
            else if ( age >= 14 && age <= 19)
            {
                bounder = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                bounder = "adult";
            }
            else if (age >= 66)
            {
                bounder = "elder";
            }

            Console.WriteLine(bounder);
        }
    }
}
