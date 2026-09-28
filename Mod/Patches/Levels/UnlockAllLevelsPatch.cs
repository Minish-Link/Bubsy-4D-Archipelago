using HarmonyLib;
using Il2CppFabraz.SaveData;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.Levels;

[HarmonyPatch(typeof(SaveData), nameof(SaveData.GetLevelBeaten))]
public static class UnlockAllLevelsPatch
{
    public static bool Postfix(bool __result)
    {
        return true;
    }
}