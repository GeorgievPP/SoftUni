using System;
using System.Linq;

namespace P01.ActionPoint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string> name = (name) =>
            {
                Console.WriteLine(name);
            };

            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(name);
        }
    }
}
