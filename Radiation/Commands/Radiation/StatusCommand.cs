using System;
using CommandSystem;
using Radiation.API;

namespace Radiation.Commands
{
    public class StatusCommand : ICommand
    {
        public string Command { get; } = "status";
        public string Description { get; } = "Show radiation status";
        public string[] Aliases { get; }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var status = RadiationAPI.Status();

            response = status.Item2;
            return true;
        }
    }
}
