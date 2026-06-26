
/*
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "ExitStatePrep")]
[HarmonyPatch(typeof(BubsyCharacterController), "ExitState")]
[HarmonyPatch(typeof(BubsyCharacterController), "ExitStateCleanup")]
[HarmonyPatch(typeof(BubsyCharacterController), "ExitStateProcess")]
public static class ExitStatePatch
{
    public static void Prefix(ref CharacterState toState, BubsyCharacterController __instance)
    {
        if (ValidStateHelper.StateIsValid(ValidStateHelper.GetReplacementState(toState, __instance), __instance) == false)
        {
            toState = __instance.State_Idle;
        }
    }

}
*/