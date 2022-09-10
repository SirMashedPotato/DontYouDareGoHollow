using Verse;

namespace Mashed_DYDGH
{
    public class DarksignExclusion : DefModExtension
    {
        public static DarksignExclusion Get(Def def)
        {
            return def.GetModExtension<DarksignExclusion>();
        }
    }
}
