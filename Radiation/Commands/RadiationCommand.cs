using System;
using System.Text;
using CommandSystem;
using NorthwoodLib.Pools;

using PluginAPI.Core;
using Radiation.Commands;

namespace Radiation
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RadiationCommand : ParentCommand
    {
        public override string Command => "radiation";
        public override string Description => "Manage facility radiation";
        public override string[] Aliases => new string[] { };


        public override void LoadGeneratedCommands()
        {
            try
            {
                RegisterCommand(new StartCommand());
                RegisterCommand(new StopCommand());
                RegisterCommand(new EnableCommand());
                RegisterCommand(new DisableCommand());
                RegisterCommand(new StatusCommand());
                RegisterCommand(new VersionCommand());
            }
            catch (Exception e)
            {
                Log.Warning("Caught an exception while registering commands.");
                Log.Debug($"{e}");
            }
            finally
            {
                Log.Info("Registered commands");
            }
        }

        public RadiationCommand() => this.LoadGeneratedCommands();

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();

            stringBuilder.AppendLine("Available commands: ");
            stringBuilder.AppendLine("- radiation start - Start doing tick damage");
            stringBuilder.AppendLine("- radiation stop - Stop doing tick damage");
            stringBuilder.AppendLine("- radiation enable - Enable tick damage, will start tick damage if warhead is detonated");
            stringBuilder.AppendLine("- radiation disable - Disable tick damage, will not start tick damage if warhead detonates");
            stringBuilder.AppendLine("- radiation status - Show radiation status");
            stringBuilder.AppendLine("- radiation version - Show plugin version");

            response = StringBuilderPool.Shared.ToStringReturn(stringBuilder);

            return false;
        }
    }
}