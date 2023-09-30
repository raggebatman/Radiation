using System;
using CommandSystem;

namespace Radiation.Commands
{
    public class VersionCommand : ICommand
    {
        public string Command { get; } = "version";
        public string Description { get; } = "Show plugin version";
        public string[] Aliases { get; }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "This server is using Radiation v1.1.1";
            return true;
        }
    }
}
