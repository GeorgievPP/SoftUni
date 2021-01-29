using P08.MilitaryElite.Contracts;
using P08.MilitaryElite.Core;
using P08.MilitaryElite.IO;
using P08.MilitaryElite.IO.Contracts;


namespace P08.MilitaryElite
{

    // 40 / 100 ;(

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
