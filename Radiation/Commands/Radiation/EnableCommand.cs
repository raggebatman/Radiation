using System;
using CommandSystem;
using NWAPIPermissionSystem;

namespace Radiation.Commands
{
    public class EnableCommand : ICommand
    {
        public string Command { get; } = "enable";
        public string Description { get; } = "Enable radiation, will start doing damage after warhead detonates";
        public string[] Aliases { get; }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("radiation.enable"))
            {
                response = "You do not have the required permission (radiation.enable) to execute this command";
                return false;
            }

            var command = Plugin.Singleton.EnableRadiation();

            response = command.Item2;
            return command.Item1;
        }
    }
}
