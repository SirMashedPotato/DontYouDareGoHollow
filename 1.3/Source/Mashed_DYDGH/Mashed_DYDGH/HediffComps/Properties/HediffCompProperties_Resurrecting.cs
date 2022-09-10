using Verse;

namespace Mashed_DYDGH
{
    public class HediffCompProperties_Resurrecting : HediffCompProperties
    {
        public HediffCompProperties_Resurrecting()
        {
            this.compClass = typeof(HediffComp_Resurrecting);
        }

        public int ticksTillResurrection = 10;
    }
}
