using Verse;

namespace Mashed_DYDGH
{
    public class HediffComp_Darksign : HediffComp
    {
        public HediffCompProperties_Darksign Props
        {
            get
            {
                return (HediffCompProperties_Darksign)this.props;
            }
        }

        public override void Notify_PawnDied()
        {
            base.Notify_PawnDied();
            Corpse corpse = Pawn.Corpse;
            if (corpse != null)
            {
                Pawn.health.AddHediff(HediffDefOf.Mashed_DYDGH_Resurrecting);
            }
        }
    }
}
