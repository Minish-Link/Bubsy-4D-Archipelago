using BubsyArchipelagoMod.Server;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.Collectables;

[HarmonyPatch(typeof(SaveData), nameof(SaveData.SetLevelTrophy))]
public static class TrophyLocationsPatch
{
    public static void Postfix(string id)
    {
        LocationSender.SendLocation($"{id}_Trophy");
    }
}

[HarmonyPatch(typeof(SaveData), nameof(SaveData.SetLevelTrophyBlackhole))]
public static class TrophyBlackholeLocationsPatch
{
    public static void Postfix(string id)
    {
        LocationSender.SendLocation($"{id}_Trophy_BH");
    }
}