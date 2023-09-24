using System;
using CommandSystem;
using NWAPIPermissionSystem;

namespace Radiation.Commands
{
    public class DisableCommand : ICommand
    {
        public string Command { get; } = "disable";
        public string Description { get; } = "Disable radiation, will not do damage after warhead detonates";
        public string[] Aliases { get; }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("radiation.disable"))
            {
                response = "You do not have the required permission (radiation.disable) to execute this command";
                return false;
            }

            if (Plugin.Singleton.DisableRadiation())
            {
                response = "Radiation has been disabled.";
                return true;
            }
            else
            {
                response = "Radiation is already disabled.";
                return false;
            }
        }
    }
}
