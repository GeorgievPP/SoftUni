using P01.Logger.Appenders.Contracts;
using P01.Logger.Appenders.Models;
using P01.Logger.Enums;
using P01.Logger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Loggers.Models
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public ICollection<IAppender> Appenders { get; private set; }

        public void Critical(string date, string message)
        {
            foreach(var appender in Appenders)
            {
                appender.Append(date, ReportLevel.CRITICAL, message);
            }
        }

        public void Error(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, ReportLevel.ERROR, message);
            }
        }

        public void Fatal(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, ReportLevel.FATAL, message);
            }
        }

        public void Info(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, ReportLevel.INFO, message);
            }
        }

        public void Warn(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, ReportLevel.WARNING, message);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach(var appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
