using System;

using VegetableNinja.Interfaces;

namespace VegetableNinja.IO
{
    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
