using Il2CppFabraz;
using HarmonyLib;
using Il2CppFabraz.Bubsy;
using Newtonsoft.Json;
using MelonLoader;
using Il2CppFabraz.SaveData;
using BubsyArchipelagoMod.Data;
using BubsyArchipelagoMod.Server;

namespace BubsyArchipelagoMod.Patches.Collectables;

[HarmonyPatch(typeof(Collectable), "Collect")]
public static class CollectableSendPatch
{
    public static void Prefix(Collectable __instance)
    {
        //MelonLogger.Msg($"Sending Location with ID of {CollectableID.GetLocationID(__instance.id.getID)}");
        Core.SendCollectableLocation(__instance.id.getID);
    }
}

[HarmonyPatch(typeof(SaveData), nameof(SaveData.AdjustCurrentYarnballCount))]
public static class AdjustYarnballPatch
{

    public static void Postfix(string id, int val, SaveData __instance)
    {
        __instance.CurrentYarnballCount -= val;
    }
}

[HarmonyPatch(typeof(SaveData), nameof(SaveData.AdjustCurrentBlueprintCount))]
public static class AdjustBlueprintPatch
{
    public static void Postfix(int val, SaveData __instance)
    {
        __instance.CurrentBlueprintCount -= val;
    }
}

[HarmonyPatch(typeof(SaveData), nameof(SaveData.AdjustCurrentGoldenFleeceCount))]
public static class AdjustGoldenFleecePatch
{
    public static void Postfix(int val, SaveData __instance)
    {
        __instance.CurrentGoldenFleeceCount -= val;
    }
}

[HarmonyPatch(typeof(SaveData), nameof(SaveData.AdjustCurrentVoidFleeceCount))]
public static class AdjustVoidFleecePatch
{
    public static void Postfix(int val, SaveData __instance)
    {
        __instance.CurrentVoidFleeceCount -= val;
    }
}