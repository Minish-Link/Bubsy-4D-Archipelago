
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using Il2CppFabraz.SaveData;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(SaveData), nameof(SaveData.SetLevelTrophy))]
[HarmonyPatch(typeof(SaveData), nameof(SaveData.SetLevelTrophyBlackhole))]

public static class TestPatch
{
    public static void Prefix(string id, SaveData __instance)
    {
        MelonLogger.Msg(__instance.blackholeModeActive);
        Bubsy4DArchi.LogPatchMessage(id, LogType.COLLECTABLE);
    }
}