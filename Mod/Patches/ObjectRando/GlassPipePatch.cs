
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.Interactables.Atari;
using Il2CppFabraz.PlayerCharacter.Bubsy;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(SuctionTubeEndPoint), nameof(SuctionTubeEndPoint.OnTriggerEnter))]
public static class SuctionTubePatch
{
    public static bool Prefix()
    {
        return ObjectInventory.PipeEntry;
    }
}

[HarmonyPatch(typeof(SuctionTubeEndPoint), nameof(SuctionTubeEndPoint.PrepCannon))]
public static class CannonPatch
{
    public static bool Prefix()
    {
        return ObjectInventory.PipeCannons;
    }
}