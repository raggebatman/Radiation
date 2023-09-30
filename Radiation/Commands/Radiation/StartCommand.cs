using System;
using CommandSystem;
using NWAPIPermissionSystem;

namespace Radiation.Commands
{
    public class StartCommand : ICommand
    {
        public string Command { get; } = "start";
        public string Description { get; } = "Start doing tick damage";
        public string[] Aliases { get; }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("radiation.start"))
            {
                response = "You do not have the required permission (radiation.start) to execute this command";
                return false;
            }

            var command = Plugin.Singleton.StartRadiation();

            response = command.Item2;
            return command.Item1;
        }
    }
}
