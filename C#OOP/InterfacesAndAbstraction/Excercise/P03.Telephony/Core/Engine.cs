using System;

using P03.Telephony.Contracts;
using P03.Telephony.Exceptions;
using P03.Telephony.Models;

namespace P03.Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(var number in phoneNumbers)
            {
                try
                {
                    if(number.Length <= 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(number));
                    }
                    else if(number.Length >= 10)
                    {
                        writer.WriteLine(smartphone.Call(number));
                    }
                }
                catch(InvalidNumberException ine)
                {
                    writer.WriteLine(ine.Message);
                }
            }

            foreach(var url in sites)
            {
                try
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch(InvalidURLException iue)
                {
                    writer.WriteLine(iue.Message);
                }
            }
        }
    }
}
