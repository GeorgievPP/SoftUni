using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<log>")
                    .AppendLine("   <date>{0}</date>")
                    .AppendLine("   <level>{1}</level>")
                    .AppendLine("   <message>{2}</message>")
                    .Append("</log>");

                return sb.ToString();
            }
        }
    }
}
