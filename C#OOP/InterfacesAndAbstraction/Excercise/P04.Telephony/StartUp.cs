using P04.Telephony.Contracts;
using P04.Telephony.IO;
using P04.Telephony.Core;

namespace P04.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
