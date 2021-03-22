
using System;
using System.Linq;

namespace Minedraft
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var manager = new DraftManager();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                var inputInfo = tokens.Skip(1).ToList();

                switch (tokens[0])
                {
                    case "RegisterHarvester":
                        Console.WriteLine(manager.RegisterHarvester(inputInfo));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(manager.RegisterProvider(inputInfo));
                        break;
                    case "Day":
                        Console.WriteLine(manager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(manager.Mode(inputInfo));
                        break;
                    case "Check":
                        Console.WriteLine(manager.Check(inputInfo));
                        break;
                    case "Shutdown":
                        Console.WriteLine(manager.ShutDown());
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
