
/*
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using static MelonLoader.MelonLogger;
namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "EnterStatePrep")]
[HarmonyPatch(typeof(BubsyCharacterController), "EnterState")]
[HarmonyPatch(typeof(BubsyCharacterController), "EnterStateCleanup")]
[HarmonyPatch(typeof(BubsyCharacterController), "EnterStateProcess")]
public static class EnterStatePatch
{
    public static void Prefix(ref CharacterState state, BubsyCharacterController __instance)
    {
        Bubsy4DArchi.LogPatchMessage(state.ToString().ToUpper());
        if (ValidStateHelper.StateIsValid(ValidStateHelper.GetReplacementState(state, __instance), __instance) == false)
        {
            state = __instance.State_Idle;
        }
        //return ValidStateHelper.StateIsValid(ValidStateHelper.GetReplacementState(state, __instance), __instance);
    }
}
*/