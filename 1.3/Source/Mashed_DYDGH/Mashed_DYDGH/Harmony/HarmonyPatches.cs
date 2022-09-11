using HarmonyLib;
using Verse;
using System.Reflection;
using RimWorld;

namespace Mashed_DYDGH
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.Mashed_DYDGH");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(PawnGenerator))]
    [HarmonyPatch("GenerateInitialHediffs")]
    public static class PawnGenerator_GenerateInitialHediffs_Patch
    {
        [HarmonyPostfix]
        public static void DarksignPatch(Pawn pawn)
        {
            if (Rand.Chance(Hollowing_ModSettings.DarksignChance))
            {
                if (pawn.Faction == null && !Hollowing_ModSettings.FactionlessPawns)
                {
                    return;
                }
                if (Faction.OfPlayerSilentFail != null && pawn.Faction == Faction.OfPlayer && !Hollowing_ModSettings.PlayerPawns)
                {
                    return;
                }
                if ((Faction.OfPlayerSilentFail == null || pawn.Faction != Faction.OfPlayer) && !Hollowing_ModSettings.NonPlayerPawns)
                {
                    return;
                }
                if (pawn.def != ThingDefOf.Human && Hollowing_ModSettings.HumanPawns)
                {
                    return;
                }
                if (pawn.RaceProps.Humanlike && (DarksignExclusion.Get(pawn.def) == null))
                {
                    pawn.health.AddHediff(HediffDefOf.DYDGH_Darksign);
                }
            }
        }
    }

    /// <summary>
    /// Ticks Mashed_DYDGH_Resurrecting, because corpses don't tick hediffs
    /// Thanks Tynan
    /// </summary>
    [HarmonyPatch(typeof(Corpse))]
    [HarmonyPatch("TickRare")]
    public static class Corpse_TickRare_DarksignPatch
    {
        [HarmonyPostfix]
        public static void RessurectionTickPatch(ref Corpse __instance)
        {
            if (__instance.GetRotStage() != RotStage.Dessicated)
            {
                Pawn p = __instance.InnerPawn;
                if (p != null && p.RaceProps.Humanlike)
                {
                    Hediff res = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.DYDGH_Resurrecting);
                    if(res != null)
                    {
                        res.TryGetComp<HediffComp_Resurrecting>().TickProgress(1);
                    }
                }
            }
        }
    }
}
