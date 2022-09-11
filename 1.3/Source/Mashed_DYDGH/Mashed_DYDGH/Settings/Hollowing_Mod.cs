using UnityEngine;
using Verse;
using System;

namespace Mashed_DYDGH
{
    public class Hollowing_Mod : Mod
    {
        Hollowing_ModSettings settings;

        public Hollowing_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<Hollowing_ModSettings>();
        }

        public override string SettingsCategory() => "Hollowing_ModName".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Hollowing_Setting_PlayerPawns".Translate(), ref settings.Hollowing_Setting_PlayerPawns);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Hollowing_Setting_NonPlayerPawns".Translate(), ref settings.Hollowing_Setting_NonPlayerPawns);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Hollowing_Setting_FactionlessPawns".Translate(), ref settings.Hollowing_Setting_FactionlessPawns);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Hollowing_Setting_HumanPawns".Translate(), ref settings.Hollowing_Setting_HumanPawns);
            listing_Standard.Gap();

            listing_Standard.Label("Hollowing_Setting_DarksignChance".Translate() + " (" + settings.Hollowing_Setting_DarksignChance * 100 + "%)");
            settings.Hollowing_Setting_DarksignChance = (float)Math.Round(listing_Standard.Slider(settings.Hollowing_Setting_DarksignChance, 0f, 1f) * 20) / 20;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Hollowing_Setting_ResurrectionBeserk".Translate(), ref settings.Hollowing_Setting_ResurrectionBeserk);
            listing_Standard.Gap();

            listing_Standard.Label("Hollowing_Setting_HollowingGain".Translate() + " (" + settings.Hollowing_Setting_HollowingGain * 100 + "%)");
            settings.Hollowing_Setting_HollowingGain = (float)Math.Round(listing_Standard.Slider(settings.Hollowing_Setting_HollowingGain, 0f, 1f) * 20) / 20;

            listing_Standard.Label("Hollowing_Setting_MoodDebuffMult".Translate() + " (" + settings.Hollowing_Setting_MoodDebuffMult + "x)");
            settings.Hollowing_Setting_MoodDebuffMult = (float)Mathf.Round(listing_Standard.Slider(settings.Hollowing_Setting_MoodDebuffMult, 0.1f, 10f) * 10) / 10;
            listing_Standard.Gap();

            listing_Standard.Label("Hollowing_Setting_ResurrectionTime".Translate() + " (" + settings.Hollowing_Setting_ResurrectionTime * 250 + ")");
            settings.Hollowing_Setting_ResurrectionTime = (int)Math.Round(listing_Standard.Slider(settings.Hollowing_Setting_ResurrectionTime, 0, 6000) / 50) * 50;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "Hollowing_Reset".Translate());
            if (Widgets.ButtonText(rectDefault, "Hollowing_Reset".Translate(), true, true, true))
            {
                Hollowing_ModSettings.ResetSettings();
            }

            listing_Standard.End();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
