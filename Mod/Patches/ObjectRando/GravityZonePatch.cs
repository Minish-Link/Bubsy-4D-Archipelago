
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using MelonLoader;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(GravityAdjustZone), nameof(GravityAdjustZone.OnTriggerEnter))]
public static class GravityZonePatch
{
    public static bool Prefix(GravityAdjustZone __instance)
    {
        if (__instance.gravityScale < 1.0)
        {
            return ObjectInventory.LowGravityZones;
        }
        else
        {
            if (ObjectInventory.HighGravityZones)
                __instance.gravityScale = 2.0f;
            else
                __instance.gravityScale = 4.0f;
            return true;
            //return ObjectInventory.HighGravityZones;
        }
    }
}