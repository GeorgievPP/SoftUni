using System;

using VegetableNinja.Interfaces;

namespace VegetableNinja.IO
{
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void Wrtite(string output)
        {
            Console.Write(output);
        }
    }
}
