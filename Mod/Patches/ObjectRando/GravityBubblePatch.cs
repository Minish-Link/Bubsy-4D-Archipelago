
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(GravityAdjustZone), nameof(GravityAdjustZone.OnTriggerEnter))]
public static class LowGravityPatch
{
    public static bool Prefix()
    {
        return ObjectInventory.LowGravityZones;
    }
}