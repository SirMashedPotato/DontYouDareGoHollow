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
            if (progress >= Props.ticksTillResurrection)
            {
                if (Pawn.Corpse != null)
                {
                    ResurrectionUtility.Resurrect(Pawn);
                    HealthUtility.AdjustSeverity(Pawn, HediffDefOf.Mashed_DYDGH_Hollowing, 0.1f);
                    if (Rand.Chance(Pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Mashed_DYDGH_Hollowing).Severity))
                    {
                        Pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk);
                    }
                }
                Pawn.health.RemoveHediff(parent);
            }
        }

        public override string CompLabelInBracketsExtra => ((float)progress / Props.ticksTillResurrection).ToStringPercent();
    }
}
