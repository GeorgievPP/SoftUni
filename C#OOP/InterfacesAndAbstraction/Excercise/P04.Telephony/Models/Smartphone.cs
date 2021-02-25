using System;
using System.Linq;

using P03.Telephony.Contracts;
using P03.Telephony.Exceptions;


namespace P03.Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Browse(string url)
        {
            if(url.Any(t => Char.IsDigit(t)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if(!number.All(n => Char.IsDigit(n)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }
    }
}
