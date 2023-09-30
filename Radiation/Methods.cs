using System.Collections.Generic;
using PluginAPI.Core;
using MEC;

using Radiation.API;
using System;

namespace Radiation
{
    public partial class Plugin
    {
        private const string RadiationDelayCoroutine = "radiation_delay";
        private const string RadiationTickCorooutine = "radiation_tick";

        public bool radiationEnabled { get; private set; } = false;
        public bool radiationStarted { get; private set; } = false;
        public bool radiationDelayed { get; private set; } = false;

        public Tuple<bool, string> StartDelay()
        {
            var status = RadiationAPI.Status();

            if (
                status.Item1 == Enums.RadiationStatus.Disabled ||
                status.Item1 == Enums.RadiationStatus.Started ||
                status.Item1 == Enums.RadiationStatus.Delayed
            ) return Tuple.Create(false, "Radiation is disabled, already started, or already delayed.");

            Timing.RunCoroutine(DelayCoroutine(), RadiationDelayCoroutine);

            radiationDelayed = true;

            return Tuple.Create(true, "Radiation delay has been started.");
        }

        public Tuple<bool, string> StopDelay()
        {
            var status = RadiationAPI.Status();

            if (
                status.Item1 != Enums.RadiationStatus.Delayed
            ) return Tuple.Create(false, "Radiation is not delayed.");

            Timing.KillCoroutines(RadiationDelayCoroutine);

            radiationDelayed = false;

            return Tuple.Create(true, "Radiation delay has been stopped.");
        }

        public Tuple<bool, string> StartRadiation()
        {
            var status = RadiationAPI.Status();

            if (
                status.Item1 == Enums.RadiationStatus.Disabled ||
                status.Item1 == Enums.RadiationStatus.Started
            ) return Tuple.Create(false, "Radiation is disabled or it has already started.");

            StopDelay();

            Timing.RunCoroutine(TickCoroutine(), RadiationTickCorooutine);

            radiationStarted = true;

            RadiationAPI.ShowHint();

            RadiationAPI.ShowBroadcast();

            return Tuple.Create(true, "Radiation has been started.");
        }

        public Tuple<bool, string> StopRadiation()
        {
            var status = RadiationAPI.Status();

            if (
                status.Item1 == Enums.RadiationStatus.Stopped
            ) return Tuple.Create(false, "Radiation has already stopped.");

            StopDelay();

            Timing.KillCoroutines(RadiationTickCorooutine);

            radiationStarted = false;

            return Tuple.Create(true, "Radiation has been stopped.");
        }

        public Tuple<bool, string> DisableRadiation()
        {
            var status = RadiationAPI.Status();

            if (
                status.Item1 == Enums.RadiationStatus.Disabled
            ) return Tuple.Create(false, "Radiation is already disabled.");

            StopDelay();

            StopRadiation();

            Log.Info("Disabled radiation");

            radiationEnabled = false;

            return Tuple.Create(true, "Radiation has been disabled.");
        }

        public Tuple<bool, string> EnableRadiation()
        {
            var status = RadiationAPI.Status();

            if (
                status.Item1 != Enums.RadiationStatus.Disabled
            ) return Tuple.Create(false, "Radiation is already enabled.");

            Log.Info("Enabled radiation");

            radiationEnabled = true;

            return Tuple.Create(true, "Radiation has been enabled.");
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