
using HarmonyLib;
using Il2CppFabraz.SaveData;
namespace BubsyArchipelagoMod.Patches.SavePatches;

[HarmonyPatch(typeof(SaveDataManager), nameof(SaveDataManager.Initialize))]
public static class FourthSaveFilePatch
{
    static void Prefix(SaveDataManager __instance)
    {
        __instance.saveSlotCount = 4;
    }
}