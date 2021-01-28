using System.Linq;

using P04.Telephony.Contracts;
using P04.Telephony.Exceptions;

namespace P04.Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
           if(!number.All(ch => char.IsDigit(ch)))
           {
               throw new InvalidNumberException();
           }

            return $"Calling... {number}";
        }
      
        public string Browse(string url)
        {
            if(url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

    }
}
