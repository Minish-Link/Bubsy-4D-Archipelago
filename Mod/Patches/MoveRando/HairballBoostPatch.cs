
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "Hairball_SetMovementState")]
public static class HairballBoostPatch
{
    public static bool Prefix(HairballStateMovementOverrideData newMovementState, ref BubsyCharacterController __instance)
    {
        if (!MoveInventory.HairballBoost && newMovementState != __instance.hairball.rollingMovementState)
        {
            if (__instance.hairball.activeMovementState != __instance.hairball.rollingMovementState)
            {
                __instance.hairball.SetMovementState(__instance.hairball.activeMovementState);
            }
            return false;
        }
        return true;
    }
}