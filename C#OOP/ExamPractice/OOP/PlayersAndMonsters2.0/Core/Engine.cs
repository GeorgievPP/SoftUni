using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController manager;

        public Engine()
        {
            this.manager = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var line = Console.ReadLine();

                    if (line == "Exit")
                    {
                        break;
                    }

                    var commandParts = line.Split();
                    var command = commandParts[0];

                    var output = string.Empty;
                    switch (command)
                    {
                        case "AddPlayer":
                            var playerType = commandParts[1];
                            var username = commandParts[2];
                            output = this.manager.AddPlayer(playerType, username);
                            break;
                        case "AddCard":
                            var cardType = commandParts[1];
                            var cardName = commandParts[2];
                            output = this.manager.AddCard(cardType, cardName);
                            break;
                        case "AddPlayerCard":
                            var playerUsername = commandParts[1];
                            var playerCardName = commandParts[2];
                            output = this.manager.AddPlayerCard(playerUsername, playerCardName);
                            break;
                        case "Fight":
                            var attakPlayerName = commandParts[1];
                            var enemyPlayerName = commandParts[2];
                            output = this.manager.Fight(attakPlayerName, enemyPlayerName);
                            break;
                        case "Report":
                            output = this.manager.Report();
                            break;
                    }

                    Console.WriteLine(output);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }    
        }
    }
}
