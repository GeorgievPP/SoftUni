using System;

using P04.Telephony.Contracts;

namespace P04.Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
