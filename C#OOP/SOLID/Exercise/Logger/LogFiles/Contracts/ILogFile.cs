using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.LogFiles.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string content);
    }
}
