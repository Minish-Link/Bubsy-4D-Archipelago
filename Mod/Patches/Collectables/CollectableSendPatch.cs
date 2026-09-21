using Il2CppFabraz;
using HarmonyLib;
using Il2CppFabraz.Bubsy;
using Newtonsoft.Json;
using MelonLoader;
using Il2CppFabraz.SaveData;
using BubsyArchipelagoMod.Data;

namespace BubsyArchipelagoMod.Patches.Collectables;

[HarmonyPatch(typeof(Collectable), "Collect")]
public static class CollectableSendPatch
{
    public static void Prefix(Collectable __instance)
    {
        //MelonLogger.Msg($"Collecting object with ID: {__instance.id.getID}");
        MelonLogger.Msg($"Sending Location with ID of {CollectableID.GetLocationID(__instance.id.getID)}");
    }
}

[HarmonyPatch(typeof(SaveData), nameof(SaveData.AdjustCurrentYarnballCount))]
public static class TestYarnballCountPatch
{
    public static void Postfix(string id, int val, SaveData __instance)
    {
        MelonLogger.Msg($"Adjusting Yarnball Count {id}, {val}, {__instance.CurrentYarnballCount}");
    }
}

//[HarmonyPatch(typeof)]