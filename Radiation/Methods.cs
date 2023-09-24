using PluginAPI.Core;
using MEC;

using Radiation.API;
using System.Collections.Generic;

namespace Radiation
{
    public partial class Plugin
    {
        private bool radiationEnabled { get; set; } = false;
        private bool radiationStarted { get; set; } = false;

        public bool StartDelay()
        {
            if (radiationStarted || !radiationEnabled) return false;

            Timing.RunCoroutine(DelayCoroutine(), "radiation_delay");

            return true;
        }

        public bool StartRadiation()
        {
            if (radiationStarted || !radiationEnabled) return false;

            Timing.RunCoroutine(TickCoroutine(), "radiation_tick");

            RadiationAPI.ShowHint();

            RadiationAPI.ShowBroadcast();

            radiationStarted = true;

            return true;
        }

        public bool StopRadiation()
        {
            if (!radiationStarted) return false;

            Timing.KillCoroutines("radiation_delay");

            Timing.KillCoroutines("radiation_tick");

            radiationStarted = false;

            return true;
        }

        public bool DisableRadiation()
        {
            if (!radiationEnabled) return false;

            radiationEnabled = false;

            StopRadiation();

            Log.Info("Disabled radiation");

            return true;
        }

        public bool EnableRadiation()
        {
            if (radiationEnabled) return false;

            radiationEnabled = true;

            if (Warhead.IsDetonated) StartRadiation();

            Log.Info("Enabled radiation");

            return true;
        }

        private IEnumerator<float> DelayCoroutine()
        {
            yield return Timing.WaitForSeconds(Config.RadiationDelay);
            StartRadiation();
        }

        private IEnumerator<float> TickCoroutine()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(Config.TickInterval);
                RadiationAPI.DealDamage();
            }
        }
    }
}