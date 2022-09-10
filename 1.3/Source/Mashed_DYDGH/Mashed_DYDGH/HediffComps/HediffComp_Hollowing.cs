using Verse;

namespace Mashed_DYDGH
{
    public class HediffComp_Hollowing : HediffComp
    {
        public HediffCompProperties_Hollowing Props
        {
            get
            {
                return (HediffCompProperties_Hollowing)this.props;
            }
        }

        public override string CompLabelInBracketsExtra => parent.Severity.ToStringPercent();
    }
}
