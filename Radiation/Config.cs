using System.Collections.Generic;
using System.ComponentModel;
using PlayerRoles;

namespace Radiation
{
    public class Config
    {
        [Description("(bool) Whether to enable radiation at the start of the round")]
        public bool EnableRadiationOnRoundStart { get; set; } = true;

        [Description("(float) How many seconds to wait after warhead detonation before starting radiation")]
        public float RadiationDelay { get; set; } = 300.0f;

        [Description("(string) The reason that gets used on Damage and Kill methods")]
        public string DeathReason { get; set; } = "Died to alpha warhead radiation.";


        [Description("(float) How many seconds to wait between dealing damage")]
        public float TickInterval { get; set; } = 2.0f;

        [Description("(float) Damage dealt to players specified as a constant")]
        public float TickDamageAbsolute { get; set; } = 10.0f;

        [Description("(float) Damage dealt to players specified as a percentage")]
        public float TickDamageRelative { get; set; } = 5.0f;


        [Description("(bool) Whether to show a broadcast when radiation starts")]
        public bool BroadcastEnable { get; set; } = true;

        [Description("(string) What text should be in the broadcast")]
        public string BroadcastText { get; set; } = "Warhead radiation has reached the surface!";

        [Description("(ushort) How many seconds the broadcast should be displayed for")]
        public ushort BroadcastDuration { get; set; } = 10;


        [Description("(bool) Whether to show a hint when radiation starts and to players whose role changes")]
        public bool HintEnable { get; set; } = false;

        [Description("(string) What text should be in the hint")]
        public string HintText { get; set; } = "Radiation Poisoning";

        [Description("(ushort) How many seconds the hint should be displayed for")]
        public ushort HintDuration { get; set; } = 10;


        [Description("(List<RoleTypeId>) What roles should be dealt constant damage to")]
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

        [Description("(List<RoleTypeId>) What roles should be dealt percentage damage to")]
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
