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
                var arguments = tokens.Skip(1).ToList();

                switch (tokens[0])
                {
                    case "RegisterHarvester":
                        Console.WriteLine(manager.RegisterHarvester(arguments));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(manager.RegisterProvider(arguments));
                        break;
                    case "Day":
                        Console.WriteLine(manager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(manager.Mode(arguments));
                        break;
                    case "Check":
                        Console.WriteLine(manager.Check(arguments));
                        break;
                    case "Shutdown":
                        Console.WriteLine(manager.ShutDown());
                        return;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
