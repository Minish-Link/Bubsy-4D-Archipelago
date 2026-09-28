
using BubsyArchipelagoMod.Helpers;
using BubsyArchipelagoMod.Instances;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppFabraz.UI.Atari;
using Il2CppInControl;
using MelonLoader;
using UnityEngine.EventSystems;

namespace BubsyArchipelagoMod.Patches.Levels;

[HarmonyPatch(typeof(FzButton), nameof(FzButton.OnSubmit))]
public static class LevelIsAccessablePatch
{
    public static bool Prefix(FzButton __instance)
    {
        MelonLogger.Msg(__instance.name);
        return LevelUnlockHelper.IsSelectedLevelUnlocked();
        //return __instance.name != "UI Button Prompt - Play";
    }
}