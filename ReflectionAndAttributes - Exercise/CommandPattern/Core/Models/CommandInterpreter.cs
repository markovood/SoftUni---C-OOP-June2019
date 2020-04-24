using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;
using CommandPattern.Core.Exceptions;
using CommandPattern.Core.Models.Commands;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string args)
        {
            // "{CommandName} {CommandArgs}"
            string[] cmdLineArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var cmdType = Assembly
                        .GetCallingAssembly()
                        .GetTypes()
                        .FirstOrDefault(t => t.Name == cmdLineArgs[0] + COMMAND_POSTFIX);

            if (cmdType == null)
            {
                throw new CommandTypeNotFoundException($"{cmdLineArgs[0]} command was not found!");
            }

            var instance = (ICommand)Activator.CreateInstance(cmdType);

            return instance.Execute(cmdLineArgs.Skip(1).ToArray());
        }
    }
}
