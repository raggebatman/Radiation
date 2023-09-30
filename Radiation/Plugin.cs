using System;
using PluginAPI.Enums;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;

using Radiation.Events;
namespace Radiation
{
    partial class Plugin
    {
        public static Plugin Singleton { get; private set; }

        [PluginConfig]
        public Config Config;

        [PluginPriority(LoadPriority.Low)]
        [PluginEntryPoint("radiation", "1.1.1", "Warhead radiation to hinder prolonged rounds.", "raggebatman")]
        public void LoadPlugin()
        {
            try
            {
                Singleton = this;

                EventManager.RegisterEvents<ServerEvents>(Singleton);

                Log.Info("Registered events");

                Singleton.EnableRadiation();
            }
            catch (Exception e)
            {
                Log.Warning("Caught an exception while loading plugin.");
                Log.Debug($"{e}");
            }
        }

        [PluginUnload]
        public void UnloadPlugin()
        {
            try
            {
                Singleton.DisableRadiation();

                EventManager.UnregisterEvents<ServerEvents>(Singleton);

                Log.Info("Unregistered events");

                Singleton = null;
            }
            catch (Exception e)
            {
                Log.Warning("Caught an exception while unloading plugin.");
                Log.Debug($"{e}");
            }
}
    }
}
