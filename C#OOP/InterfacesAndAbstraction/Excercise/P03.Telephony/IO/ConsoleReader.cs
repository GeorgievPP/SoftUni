﻿using System;
using P03.Telephony.Contracts;

namespace P03.Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
