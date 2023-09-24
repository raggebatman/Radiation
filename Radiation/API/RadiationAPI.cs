using PluginAPI.Core;
using PlayerStatsSystem;

namespace Radiation.API
{
    public static class RadiationAPI
    {
        private static readonly Config _config = Plugin.Singleton.Config;

        public static bool ShowHint()
        {
            if (!_config.HintEnable) return false;

            var players = Player.GetPlayers();

            if (players.IsEmpty()) return false;

            foreach (Player player in players)
            {
                var id = player.RoleBase.RoleTypeId;

                if (_config.TakesAbsoluteDamage.Contains(id) || _config.TakesRelativeDamage.Contains(id))
                {
                    player.ReceiveHint(_config.HintText, _config.HintDuration);
                }
            }

            return true;
        }

        public static bool ShowBroadcast()
        {
            if (!_config.BroadcastEnable) return false;

            Server.SendBroadcast(_config.BroadcastText, _config.BroadcastDuration);

            return true;
        }

        public static void DealDamage()
        {
            var players = Player.GetPlayers();

            foreach (Player player in players)
            {
                if (!player.IsAlive) continue;

                var health = player.GetStatModule<HealthStat>();

                var id = player.RoleBase.RoleTypeId;

                float damage;

                if (_config.TakesAbsoluteDamage.Contains(id))
                {
                    damage = _config.TickDamageAbsolute;
                }
                else
                if (_config.TakesRelativeDamage.Contains(id))
                {
                    damage = (health.MaxValue / 100) * _config.TickDamagePercent;
                }
                else
                {
                    continue;
                }

                if (health.CurValue - damage > 0f)
                {
                    player.Damage(damage, _config.DeathReason);
                }
                else
                {
                    player.Kill(_config.DeathReason);
                }
            }
        }
    }
}
