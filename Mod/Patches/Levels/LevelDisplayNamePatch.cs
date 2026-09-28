using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.UI.Atari;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.Levels;

[HarmonyPatch(typeof(TurningText), nameof(TurningText.SwapText))]
public static class LevelDisplayNamePatch
{
    public static void Prefix(ref string newText, TurningText __instance)
    {
        if (__instance.name != "Level Name" || newText.Length < 2 || newText[1] != '-')
            return;
        newText = LevelUnlockHelper.GetUnavailableLevelText(newText);
        //__instance.text.text = LevelUnlockHelper.GetUnavailableLevelText(newText);
        //__instance.nextText = LevelUnlockHelper.GetUnavailableLevelText(newText);
        //__instance.isTurning = true;
        //return false;
    }
}