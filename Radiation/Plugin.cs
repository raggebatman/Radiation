using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;

using Radiation.Events;
using System;
using PluginAPI.Enums;

namespace Radiation
{
    partial class Plugin
    {
        public static Plugin Singleton { get; set; }

        [PluginConfig]
        public Config Config;

        [PluginPriority(LoadPriority.Low)]
        [PluginEntryPoint("radiation", "1.0.0", "Warhead radiation to hinder prolonged rounds.", "raggebatman")]
        void LoadPlugin()
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
