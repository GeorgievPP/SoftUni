using System;

namespace MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double aPow = Math.Pow(a, b);

            Console.WriteLine(aPow);
        }

    }
}
