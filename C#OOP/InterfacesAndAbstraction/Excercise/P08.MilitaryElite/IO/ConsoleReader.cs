using System;

using P08.MilitaryElite.IO.Contracts;

namespace P08.MilitaryElite.IO
{
    public class ConsoleReader :IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
