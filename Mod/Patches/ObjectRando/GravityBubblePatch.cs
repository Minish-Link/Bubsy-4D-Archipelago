
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using MelonLoader;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(GravityAdjustZone), nameof(GravityAdjustZone.OnTriggerEnter))]
public static class LowGravityPatch
{
    public static bool Prefix(GravityAdjustZone __instance)
    {
        return false;
        if (__instance.gravityScale < 1.0)
        {
            return ObjectInventory.LowGravityZones;
        }
        else
        {
            return ObjectInventory.HighGravityZones;
        }
    }
}