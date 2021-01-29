using System;

using P08.MilitaryElite.IO.Contracts;


namespace P08.MilitaryElite.IO
{
    public class ConsoleWriter :IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
