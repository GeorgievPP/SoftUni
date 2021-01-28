using System.Linq;

using P04.Telephony.Contracts;
using P04.Telephony.Exceptions;

namespace P04.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
                
        }
        public string Call(string number)
        {
            if(!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}
