using System;
using System.Linq;

using P03.Telephony.Contracts;
using P03.Telephony.Exceptions;

namespace P03.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if(!number.All(n => Char.IsDigit(n)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}
