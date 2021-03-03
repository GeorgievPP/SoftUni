using P01.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
