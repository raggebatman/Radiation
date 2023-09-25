using System.Collections.Generic;
using PluginAPI.Core;
using MEC;

using Radiation.API;

namespace Radiation
{
    public partial class Plugin
    {
        public bool radiationEnabled { get; private set; } = false;
        public bool radiationStarted { get; private set; } = false;
        public bool radiationDelayed { get; private set; } = false;

        public bool StartDelay()
        {
            if (radiationStarted || !radiationEnabled || radiationDelayed) return false;

            Timing.RunCoroutine(DelayCoroutine(), "radiation_delay");

            radiationDelayed = true;

            return true;
        }

        public bool StartRadiation()
        {
            if (radiationStarted || !radiationEnabled) return false;

            Timing.KillCoroutines("radiation_delay");

            radiationDelayed = false;

            Timing.RunCoroutine(TickCoroutine(), "radiation_tick");

            radiationStarted = true;

            RadiationAPI.ShowHint();

            RadiationAPI.ShowBroadcast();

            return true;
        }

        public bool StopRadiation()
        {
            if (!radiationStarted) return false;

            Timing.KillCoroutines("radiation_delay");

            radiationDelayed = false;

            Timing.KillCoroutines("radiation_tick");

            radiationStarted = false;

            return true;
        }

        public bool DisableRadiation()
        {
            if (!radiationEnabled) return false;

            Timing.KillCoroutines("radiation_delay");

            radiationDelayed = false;

            Timing.KillCoroutines("radiation_tick");

            radiationStarted = false;

            Log.Info("Disabled radiation");

            radiationEnabled = false;

            return true;
        }

        public bool EnableRadiation()
        {
            if (radiationEnabled) return false;

            radiationEnabled = true;

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