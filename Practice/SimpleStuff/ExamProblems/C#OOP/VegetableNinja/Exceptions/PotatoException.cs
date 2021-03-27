using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableNinja.Exceptions
{
    public class PotatoException : Exception
    {
        public PotatoException(string message) : base(message)
        {
        }
    }
}
