using P01.Logger.Enums;
using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Appenders.Contracts
{
    public interface IAppender 
    {
        ILayout Layout { get; }

        void Append(string date, ReportLevel level, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
