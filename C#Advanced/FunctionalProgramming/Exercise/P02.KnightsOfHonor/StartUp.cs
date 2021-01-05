using System;
using System.Linq;

namespace P02.KnightsOfHonor
{
    class StartUp
    {
        static void Main(string[] args)
        {

         //  Action<string> honor = (name) =>
         //  {
         //
         //      Console.WriteLine("Sir " + name);
         //
         //  };
         //
         //  Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
         //      .ToList().ForEach(honor);
         //
         //
         //  else:

            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(new Action<string>((name =>
                {

                   Console.WriteLine("Sir " + name);

                })));
        }
    }
}
