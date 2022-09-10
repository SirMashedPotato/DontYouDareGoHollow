using Verse;
using RimWorld;

namespace Mashed_DYDGH
{
	[DefOf]
	public static class NeedDefOf
	{

		static NeedDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(NeedDefOf));
		}

		public static NeedDef Mood;
	}
}
