using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableNinja.Core;
using VegetableNinja.Data;
using VegetableNinja.Interfaces;
using VegetableNinja.IO;

namespace VegetableNinja
{
    public class Launcher
    {
        static void Main(string[] args)
        {
            IInputReader consoleReader = new ConsoleReader();

            IOutputWriter consoleWriter = new ConsoleWriter();

            IDatabase database = new Database();

            IGameController gameController = new GameController(database);

            IEngine engine = new Engine(consoleReader, consoleWriter, gameController);
            engine.Run();
        }
    }
}
