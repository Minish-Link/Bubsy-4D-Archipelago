
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.Interactables;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(Bouncer), nameof(Bouncer.Trigger))]
public static class BouncerPatch
{
    public static bool Prefix()
    {
        return ObjectInventory.Springs;
    }
}