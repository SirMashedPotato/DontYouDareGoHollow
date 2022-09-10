using HarmonyLib;
using Verse;
using System.Reflection;
using RimWorld;
using UnityEngine;

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
        public static void BirthsignPatch(Pawn pawn)
        {
            //if (Rand.Chance(BirthSigns_ModSettings.ChanceHasSign))
            //{
                if (pawn.RaceProps.Humanlike && (DarksignExclusion.Get(pawn.def) == null /*|| BirthSigns_ModSettings.AllowDisabledRaces)*/))
                {
                    pawn.health.AddHediff(HediffDefOf.Mashed_DYDGH_Darksign);
                }
            //}
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
                    Hediff res = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Mashed_DYDGH_Resurrecting);
                    if(res != null)
                    {
                        res.TryGetComp<HediffComp_Resurrecting>().TickProgress(1);
                    }
                }
            }
        }
    }
}
