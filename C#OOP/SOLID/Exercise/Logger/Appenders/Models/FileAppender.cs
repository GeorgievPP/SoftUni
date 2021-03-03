using P01.Logger.Enums;
using P01.Logger.Layouts.Contracts;
using P01.Logger.LogFiles;
using P01.Logger.LogFiles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Appenders.Models
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout) : base(layout)
        {
        }

        public ILogFile File { get; set; }

        public override void Append(string date, ReportLevel level, string message)
        {
            if(level >= ReportLevel)
            {
                this.File.Write(String.Format(Layout.Format, date, level, message));
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
