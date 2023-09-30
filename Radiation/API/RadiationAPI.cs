using PluginAPI.Core;
using PlayerStatsSystem;
using Radiation.Enums;
using PlayerRoles;
using System;

namespace Radiation.API
{
    public static class RadiationAPI
    {
        private static readonly Config _config = Plugin.Singleton.Config;

        public static RadiationDamage RadiationDamageType(RoleTypeId roleTypeId)
        {
            if (_config.TakesAbsoluteDamage.Contains(roleTypeId))
            {
                return RadiationDamage.Absolute;
            }
            else
            if (_config.TakesRelativeDamage.Contains(roleTypeId))
            {
                return RadiationDamage.Relative;
            }
            else
            {
                return RadiationDamage.None;
            }
        }

        public static RadiationDamage RadiationDamageType(Player player)
        {
            return RadiationDamageType(player.RoleBase.RoleTypeId);
        }

        public static bool ShowHint(Player player, RoleTypeId roleTypeId)
        {
            if (!_config.HintEnable) return false;

            switch (RadiationDamageType(roleTypeId))
            {
                case RadiationDamage.Absolute:
                case RadiationDamage.Relative:
                    player.ReceiveHint(_config.HintText, _config.HintDuration);
                    return true;

                default:
                    return false;
            }
        }

        public static bool ShowHint(Player player)
        {
            return ShowHint(player, player.RoleBase.RoleTypeId);
        }
        public static bool ShowHint()
        {
            bool flag = false;

            foreach (Player player in Player.GetPlayers())
            {
                if (ShowHint(player))
                {
                    flag = true;
                }
            }

            return flag;
        }

        public static bool ShowBroadcast()
        {
            if (!_config.BroadcastEnable) return false;

            Server.SendBroadcast(_config.BroadcastText, _config.BroadcastDuration);

            return true;
        }

        public static bool DealDamage()
        {
            bool flag = false;

            foreach (Player player in Player.GetPlayers())
            {
                if (DealDamage(player))
                {
                    flag = true;
                }
            }

            return flag;
        }

        public static bool DealDamage(Player player)
        {
            if (!player.IsAlive) return false;

            var health = player.GetStatModule<HealthStat>();

            float damage;

            switch (RadiationDamageType(player))
            {
                case RadiationDamage.Absolute:
                    damage = _config.TickDamageAbsolute;
                    break;

                case RadiationDamage.Relative:
                    damage = (health.MaxValue / 100) * _config.TickDamageRelative;
                    break;

                default:
                    return false;
            }

            if (health.CurValue - damage > 0f)
            {
                player.Damage(damage, _config.DeathReason);
            }
            else
            {
                player.Kill(_config.DeathReason);
            }

            return true;
        }

        public static Tuple<RadiationStatus, string> Status()
        {
            RadiationStatus status;
            string response;

            if (!Plugin.Singleton.radiationEnabled)
            {
                status = RadiationStatus.Disabled;
                response = "Radiation is disabled.";
            }
            else
            if (Plugin.Singleton.radiationDelayed)
            {
                status = RadiationStatus.Delayed;
                response = "Radiation will occur soon.";
            }
            else
            if (Plugin.Singleton.radiationStarted)
            {
                status = RadiationStatus.Started;
                response = "Radiation is active.";
            }
            else
            {
                status = RadiationStatus.Stopped;
                response = "Radiation is inactive.";
            }

            return Tuple.Create(status, response);
        }
    }
}
