
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.PlayerCharacter;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(CharacterAirStateReset), nameof(CharacterAirStateReset.ResetAirState))]
public static class FanAirStatePatch
{
    public static bool Prefix()
    {
        return ObjectInventory.Fans;
    }
}

[HarmonyPatch(typeof(ApplyConstantForce), nameof(ApplyConstantForce.Update))]
[HarmonyPatch(typeof(ApplyConstantForce), nameof(ApplyConstantForce.FixedUpdate))]
public static class FanForcePatch
{
    public static bool Prefix()
    {
        return ObjectInventory.Fans;
    }
}