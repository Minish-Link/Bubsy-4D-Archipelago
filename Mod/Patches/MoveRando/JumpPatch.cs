

using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using MelonLoader;


namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "TryJump")]
public static class JumpPatch
{
    public static void Postfix(bool jumpRequested, ref CharacterState resultingState, BubsyCharacterController __instance)
    {
        if (resultingState != null)
        {
            if (resultingState == __instance.State_PounceLandingLeap)
            {
                // This one doesn't work
                MelonLogger.Msg("Trying to prevent Pounce Landing Leap");
                resultingState = __instance.State_Jump1;
            }
            if (resultingState == __instance.State_SkidJump && !MoveInventory.SkidJump)
            {
                MelonLogger.Msg("Trying to prevent SkidJump");
                resultingState = __instance.State_Jump1;
            }
            if (resultingState == __instance.State_Jump1 && !MoveInventory.Jump)
            {
                if (MoveInventory.DoubleJump)
                {
                    resultingState = __instance.State_Jump2;
                }
                else if (MoveInventory.TripleJump)
                {
                    resultingState = __instance.State_Jump3;
                }
                else
                {
                    resultingState = __instance.State_Idle;
                }
            }
        }
    }
}