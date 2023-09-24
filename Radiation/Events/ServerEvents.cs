﻿using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace Radiation.Events
{
    public class ServerEvents
    {
        private readonly Config _config;

        public ServerEvents()
        {
            _config = Plugin.Singleton.Config;
        }

        [PluginEvent(ServerEventType.RoundStart)]
        private void OnRoundStart(RoundStartEvent @event)
        {
            Plugin.Singleton.StopRadiation();

            if (!_config.EnableRadiationOnRoundStart) return;

            Plugin.Singleton.EnableRadiation();
        }

        [PluginEvent(ServerEventType.RoundEnd)]
        private void OnRoundEnd(RoundEndEvent @event)
        {
            Plugin.Singleton.StopRadiation();
        }

        [PluginEvent(ServerEventType.RoundRestart)]
        private void OnRoundRestart(RoundRestartEvent @event)
        {
            Plugin.Singleton.StopRadiation();
        }

        [PluginEvent(ServerEventType.WarheadDetonation)]
        private void OnWarheadDetonation(WarheadDetonationEvent @event)
        {
            Plugin.Singleton.StartDelay();
        }
    }
}