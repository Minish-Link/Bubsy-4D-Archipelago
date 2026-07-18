
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using Il2CppFabraz.SaveData;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(SaveData), nameof(SaveData.SetLevelTrophy))]

public static class TestPatch
{
    public static void Prefix(string id)
    {
        Bubsy4DArchi.LogPatchMessage(id, LogType.COLLECTABLE);
    }
}