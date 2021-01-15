using System;

namespace P01.RhumbusAsStars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var rhombusDrawer = new RhumbusAsStringDrawer();

            var rhombusAsString = rhombusDrawer.Draw(n);

            Console.WriteLine(rhombusAsString);

        }
    }
}
