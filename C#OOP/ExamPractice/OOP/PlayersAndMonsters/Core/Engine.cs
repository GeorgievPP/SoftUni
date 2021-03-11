using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController controller;

        public Engine(IManagerController managerController)
        {
            this.controller = managerController;
        }

        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "Exit")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            string type = cmdArgs[1];
                            string username = cmdArgs[2];

                            result = controller.AddPlayer(type, username);
                            break;

                        case "AddCard":
                            string cardType = cmdArgs[1];
                            string name = cmdArgs[2];

                            result = controller.AddCard(cardType, name);
                            break;

                        case "AddPlayerCard":
                            string usernamePlayer = cmdArgs[1];
                            string cardName = cmdArgs[2];

                            result = this.controller.AddPlayerCard(usernamePlayer, cardName);
                            break;

                        case "Fight":
                            string attacker = cmdArgs[1];
                            string enemy = cmdArgs[2];

                            result = this.controller.Fight(attacker, enemy);
                            break;

                        case "Report":
                            result = this.controller.Report();
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
