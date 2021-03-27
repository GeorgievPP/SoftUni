using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableNinja.Interfaces
{
    public interface IGameController
    {
        IDatabase Database { get; }

        INinja WinnerNinja { get; }

        void ProcessInput(string inputLine);

        void InitialiseGameData(string firstNinjaName);
    }
}
