using System;
using CommandSystem;
using NWAPIPermissionSystem;

namespace Radiation.Commands
{
    public class StopCommand : ICommand
    {
        public string Command { get; } = "stop";
        public string Description { get; } = "Stop doing tick damage";
        public string[] Aliases { get; }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("radiation.stop"))
            {
                response = "You do not have the required permission (radiation.stop) to execute this command";
                return false;
            }

            if (Plugin.Singleton.StopRadiation())
            {
                response = "Radiation has been stopped.";
                return true;
            }
            else
            {
                response = "Radiation has already stopped.";
                return false;
            }
        }
    }
}
