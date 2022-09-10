using Verse;
using RimWorld;

namespace Mashed_DYDGH
{
	[DefOf]
	public static class HediffDefOf
	{

		static HediffDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
		}

		public static HediffDef Mashed_DYDGH_Darksign;
		public static HediffDef Mashed_DYDGH_Hollowing;
		public static HediffDef Mashed_DYDGH_Resurrecting;
	}
}
