using P01.Logger.Enums;
using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Appenders.Models
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string date, ReportLevel level, string message)
        {
            if(level >= ReportLevel)
            {
                Console.WriteLine(String.Format(Layout.Format, date, level, message));
                this.MessagesCount++;
            }
        }
    }
}
