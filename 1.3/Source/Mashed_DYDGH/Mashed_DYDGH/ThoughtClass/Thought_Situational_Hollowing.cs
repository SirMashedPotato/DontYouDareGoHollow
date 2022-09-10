using Verse;
using RimWorld;

namespace Mashed_DYDGH
{
    public class Thought_Situational_Hollowing : Thought_Situational
    {
        public override float MoodOffset()
        {
            Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(def.hediff);
            float factor = hediff != null ? hediff.Severity*100f : 1f;
            return BaseMoodOffset * factor;
        }
    }
}
