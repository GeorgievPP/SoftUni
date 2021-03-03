using P01.Logger.Appenders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Loggers.Contracts
{
    public interface ILogger
    {
        ICollection<IAppender> Appenders { get; }

        void Warn(string date, string message);

        void Critical(string date, string message);

        void Error(string date, string message);

        void Fatal(string date, string message);

        void Info(string date, string message);
    }
}
