using System;
using CommandSystem;
using NWAPIPermissionSystem;

namespace Radiation.Commands
{
    public class StatusCommand : ICommand
    {
        public string Command { get; } = "status";
        public string Description { get; } = "Show radiation status";
        public string[] Aliases { get; }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("radiation.status"))
            {
                response = "You do not have the required permission (radiation.status) to execute this command";
                return false;
            }

            if (!Plugin.Singleton.radiationEnabled)
            {
                response = "Radiation is disabled.";
            }
            else
            if (Plugin.Singleton.radiationDelayed)
            {
                response = "Radiation will occur soon.";
            }
            else
            if (Plugin.Singleton.radiationStarted)
            {
                response = "Radiation is active.";
            }
            else
            {
                response = "Radiation is inactive.";
            }

            return true;
        }
    }
}
