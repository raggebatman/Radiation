using System.Collections.Generic;
using System.ComponentModel;
using PlayerRoles;

namespace Radiation
{
    public class Config
    {
        [Description("Whether or not to enable radiation at the start of the round.\n# If false, radiation will not start after warhead detonation if it had been disabled the round prior.\n# Type: float")]
        public bool EnableRadiationOnRoundStart { get; set; } = true;

        [Description("The delay in seconds after warhead detonation before radiation damage is dealt.\n# Type: float")]
        public float RadiationDelay { get; set; } = 300.0f;

        [Description("The death reason that the player will see due to this plugin.\n# Type: string")]
        public string DeathReason { get; set; } = "Died to alpha warhead radiation.";


        [Description("The timeframe between each damage tick specified in seconds.\n# Type: float")]
        public float TickInterval { get; set; } = 2.0f;

        [Description("The damage that is dealt to the player as an absolute value.\n# Type: float")]
        public float TickDamageAbsolute { get; set; } = 10.0f;

        [Description("The damage that is dealt to the player as a percentage of their max health.\n# Type: float")]
        public float TickDamagePercent { get; set; } = 5.0f;


        [Description("Enable or disable a broadcast to show when radiation has started.\n# Type: bool")]
        public bool BroadcastEnable { get; set; } = true;

        [Description("The text that is shown in the broadcast.\n# Type: string")]
        public string BroadcastText { get; set; } = "Warhead radiation has reached the surface!";

        [Description("The duration in seconds of the broadcast.\n# Type: ushort")]
        public ushort BroadcastDuration { get; set; } = 10;


        [Description("Enable or disable a hint to show players that radiation has started.\n# Type: bool")]
        public bool HintEnable { get; set; } = false;

        [Description("The text that is shown in the hint.\n# Type: string")]
        public string HintText { get; set; } = "Radiation Poisoning";

        [Description("The duration in seconds of the hint.\n# Type: ushort")]
        public ushort HintDuration { get; set; } = 10;


        [Description("Select which roles will take absolute damage from radiation.\n# Type: List<RoleTypeId>")]
        public List<RoleTypeId> TakesAbsoluteDamage { get; set; } = new List<RoleTypeId>()
        {
            RoleTypeId.ChaosConscript,
            RoleTypeId.ChaosMarauder,
            RoleTypeId.ChaosRepressor,
            RoleTypeId.ChaosRifleman,
            RoleTypeId.ClassD,
            RoleTypeId.FacilityGuard,
            RoleTypeId.NtfCaptain,
            RoleTypeId.NtfPrivate,
            RoleTypeId.NtfSergeant,
            RoleTypeId.NtfSpecialist,
            RoleTypeId.Scientist,
            RoleTypeId.Tutorial
        };

        [Description("Select which roles will take percentage damage from radiation.\n# Type: List<RoleTypeId>")]
        public List<RoleTypeId> TakesRelativeDamage { get; set; } = new List<RoleTypeId>()
        {
            RoleTypeId.Scp049,
            RoleTypeId.Scp0492,
            RoleTypeId.Scp096,
            RoleTypeId.Scp106,
            RoleTypeId.Scp173,
            RoleTypeId.Scp939
        };
    }
}
