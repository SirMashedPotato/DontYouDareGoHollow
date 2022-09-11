using Verse;

namespace Mashed_DYDGH
{
    public class Hollowing_ModSettings : ModSettings
    {
        private static Hollowing_ModSettings _instance;

        public Hollowing_ModSettings()
        {
            _instance = this;
        }

        /* ==========[GETTERS]========== */
        public static bool PlayerPawns => _instance.Hollowing_Setting_PlayerPawns;
        public static bool NonPlayerPawns => _instance.Hollowing_Setting_NonPlayerPawns;
        public static bool FactionlessPawns => _instance.Hollowing_Setting_FactionlessPawns;
        public static bool HumanPawns => _instance.Hollowing_Setting_HumanPawns;
        public static float DarksignChance => _instance.Hollowing_Setting_DarksignChance;
        public static float HollowingGain => _instance.Hollowing_Setting_HollowingGain;
        public static float MoodDebuffMult => _instance.Hollowing_Setting_MoodDebuffMult;
        public static bool ResurrectionBeserk => _instance.Hollowing_Setting_ResurrectionBeserk;
        public static int ResurrectionTime => _instance.Hollowing_Setting_ResurrectionTime;

        /* ==========[VARIABLES]========== */
        public bool Hollowing_Setting_PlayerPawns = Hollowing_Setting_PlayerPawns_def;
        public bool Hollowing_Setting_NonPlayerPawns = Hollowing_Setting_NonPlayerPawns_def;
        public bool Hollowing_Setting_FactionlessPawns = Hollowing_Setting_FactionlessPawns_def;
        public bool Hollowing_Setting_HumanPawns = Hollowing_Setting_HumanPawns_def;
        public float Hollowing_Setting_DarksignChance = Hollowing_Setting_DarksignChance_def;
        public float Hollowing_Setting_HollowingGain = Hollowing_Setting_HollowingGain_def;
        public float Hollowing_Setting_MoodDebuffMult = Hollowing_Setting_MoodDebuffMult_def;
        public bool Hollowing_Setting_ResurrectionBeserk = Hollowing_Setting_ResurrectionBeserk_def;
        public int Hollowing_Setting_ResurrectionTime = Hollowing_Setting_ResurrectionTime_def;

        /* ==========[DEFAULTS]========== */
        private static readonly bool Hollowing_Setting_PlayerPawns_def = true;
        private static readonly bool Hollowing_Setting_NonPlayerPawns_def = true;
        private static readonly bool Hollowing_Setting_FactionlessPawns_def = true;
        private static readonly bool Hollowing_Setting_HumanPawns_def = false;
        private static readonly float Hollowing_Setting_DarksignChance_def = 1f;
        private static readonly float Hollowing_Setting_HollowingGain_def = 0.05f;
        private static readonly float Hollowing_Setting_MoodDebuffMult_def = 1f;
        private static readonly bool Hollowing_Setting_ResurrectionBeserk_def = true;
        private static readonly int Hollowing_Setting_ResurrectionTime_def = 100;

        /* ==========[SAVING]========== */
        public override void ExposeData()
        {
            Scribe_Values.Look(ref Hollowing_Setting_PlayerPawns, "Hollowing_Setting_PlayerPawns", Hollowing_Setting_PlayerPawns_def);
            Scribe_Values.Look(ref Hollowing_Setting_NonPlayerPawns, "Hollowing_Setting_NonPlayerPawns", Hollowing_Setting_NonPlayerPawns_def);
            Scribe_Values.Look(ref Hollowing_Setting_FactionlessPawns, "Hollowing_Setting_FactionlessPawns", Hollowing_Setting_FactionlessPawns_def);
            Scribe_Values.Look(ref Hollowing_Setting_HumanPawns, "Hollowing_Setting_HumanPawns", Hollowing_Setting_HumanPawns_def);
            Scribe_Values.Look(ref Hollowing_Setting_DarksignChance, "Hollowing_Setting_DarksignChance", Hollowing_Setting_DarksignChance_def);
            Scribe_Values.Look(ref Hollowing_Setting_HollowingGain, "Hollowing_Setting_HollowingGain", Hollowing_Setting_HollowingGain_def);
            Scribe_Values.Look(ref Hollowing_Setting_MoodDebuffMult, "Hollowing_Setting_MoodDebuffMult", Hollowing_Setting_MoodDebuffMult_def);
            Scribe_Values.Look(ref Hollowing_Setting_ResurrectionBeserk, "Hollowing_Setting_ResurrectionBeserk", Hollowing_Setting_ResurrectionBeserk_def);
            Scribe_Values.Look(ref Hollowing_Setting_ResurrectionTime, "Hollowing_Setting_ResurrectionTime", Hollowing_Setting_ResurrectionTime_def);
            base.ExposeData();
        }

        /* ==========[Resetting]========== */
        public static void ResetSettings()
        {
            _instance.Hollowing_Setting_PlayerPawns = Hollowing_Setting_PlayerPawns_def;
            _instance.Hollowing_Setting_NonPlayerPawns = Hollowing_Setting_NonPlayerPawns_def;
            _instance.Hollowing_Setting_FactionlessPawns = Hollowing_Setting_FactionlessPawns_def;
            _instance.Hollowing_Setting_HumanPawns = Hollowing_Setting_HumanPawns_def;
            _instance.Hollowing_Setting_DarksignChance = Hollowing_Setting_DarksignChance_def;
            _instance.Hollowing_Setting_HollowingGain = Hollowing_Setting_HollowingGain_def;
            _instance.Hollowing_Setting_MoodDebuffMult = Hollowing_Setting_MoodDebuffMult_def;
            _instance.Hollowing_Setting_ResurrectionBeserk = Hollowing_Setting_ResurrectionBeserk_def;
            _instance.Hollowing_Setting_ResurrectionTime = Hollowing_Setting_ResurrectionTime_def;
        }
    }
}
