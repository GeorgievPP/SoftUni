using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    //Holds all the reflection we should do in order to execute a command 

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public CommandInterpreter()
        {

        }

        public string Read(string args)
        {
            string[] commandTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = commandTokens[0] + COMMAND_POSTFIX;
            string[] commandArgs = commandTokens.Skip(1).ToArray();

            // Get assembly in order to get types
            Assembly assembly = Assembly.GetCallingAssembly();

            //Get concreate command type in order to produce instance of concrete command
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if(commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            //Create instance of concrete command in order to invoke Execute()

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);
            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
