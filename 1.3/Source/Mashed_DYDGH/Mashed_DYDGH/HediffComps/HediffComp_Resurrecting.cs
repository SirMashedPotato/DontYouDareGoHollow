using Verse;
using RimWorld;

namespace Mashed_DYDGH
{
    public class HediffComp_Resurrecting : HediffComp
    {
        public HediffCompProperties_Resurrecting Props
        {
            get
            {
                return (HediffCompProperties_Resurrecting)this.props;
            }
        }

        public int progress = 0;

        public override void CompExposeData()
        {
            Scribe_Values.Look(ref progress, "resurrectionProgress", 0);
            base.CompExposeData();
        }

        public void TickProgress(int amount)
        {
            progress += amount;
            int target = Hollowing_ModSettings.ResurrectionTime;
            if (progress >= target)
            {
                if (Pawn.Corpse != null)
                {
                    ResurrectionUtility.Resurrect(Pawn);
                    HealthUtility.AdjustSeverity(Pawn, HediffDefOf.DYDGH_Hollowing, Hollowing_ModSettings.HollowingGain);
                    if (Hollowing_ModSettings.ResurrectionBeserk && Rand.Chance(Pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.DYDGH_Hollowing).Severity))
                    {
                        Pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk);
                    }
                }
                Pawn.health.RemoveHediff(parent);
            }
        }

        public override string CompLabelInBracketsExtra => ((float)progress / Hollowing_ModSettings.ResurrectionTime).ToStringPercent();
    }
}
