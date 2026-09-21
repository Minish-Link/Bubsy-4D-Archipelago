
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppFabraz.UI.Atari;
using Il2CppInControl;
using MelonLoader;
using UnityEngine.EventSystems;

namespace BubsyArchipelagoMod.Patches.Levels;


[HarmonyPatch(typeof(SaveData), nameof(SaveData.GetLevelBeaten))]
public static class LevelBeatenPatch
{
    public static bool Postfix(bool _result, string id, SaveData __instance)
    {
        return true;
    }
}

public static class LevelIsAccessablePatch
{
    [HarmonyPatch(typeof(FzButton), nameof(FzButton.OnSubmit))]
    public static bool Prefix(FzButton __instance)
    {
        MelonLogger.Msg(__instance.name);
        return __instance.name != "UI Button Prompt - Play";
    }
}