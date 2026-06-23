
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.Interactables.Atari;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;
[HarmonyPatch(typeof(BubsyCharacterController), "TryStandardActions")]
public static class StandardActionsPatch
{
    private static string previous_state_string = "";

    public static void Prefix(ref CharacterState __state, BubsyCharacterController __instance)
    {
        __state = __instance.CurrentCharacterState;
    }

    public static void Postfix(ref CharacterState state, CharacterState __state, BubsyCharacterController __instance)
    {
        if (__state == null)
            return;
        string next_state_string = state.ToString().Split(' ')[0];
        if (next_state_string != previous_state_string)
        {
            Bubsy4DArchi.LogPatchMessage($"Switching from {previous_state_string} to {next_state_string}");
            previous_state_string = next_state_string;
        }

        if (CancelJump(ref state, ref __instance)) return;
        if (CancelGlide(ref state, ref __instance)) return;
        if (CancelPounce(ref state, ref __instance)) return;
        if (CancelFlutterStep(ref state, ref __instance)) return;
        if (PreventSkid(ref state, ref __instance)) return;
    }

    private static bool CancelJump(ref CharacterState state, ref BubsyCharacterController instance)
    {
        bool willCancel = false;

        if (state == instance.State_SkidJump)
        {
            if (!MoveInventory.SkidJump)
            {
                state = instance.State_Jump1;
                willCancel = true;
            }
        }
        else if (state == instance.State_Jump3)
        {
            if (!MoveInventory.TripleJump)
            {
                state = instance.State_Jump1;
                willCancel = true;
            }
        }
        else if (state == instance.State_Jump2)
        {
            if (!MoveInventory.DoubleJump)
            {
                state = instance.State_Jump1;
                willCancel = true;
            }
        }
        // Other jump cancels will deteriorate to the basic jump before being cancelled entirely.
        if (state == instance.State_Jump1 || state == instance.State_SprintJump)
        {
            if (!MoveInventory.Jump)
            {
                state = instance.State_Idle;
                willCancel = true;
            }
        }

        return willCancel;
    }

    private static bool CancelPounce(ref CharacterState state, ref BubsyCharacterController instance)
    {
        if (state == instance.State_Pounce || state == instance.State_SprintPounce)
        {
            if (!MoveInventory.Pounce)
            {
                state = instance.State_Idle;
                return true;
            }
        }
        return false;
    }

    private static bool CancelGlide(ref CharacterState state, ref BubsyCharacterController instance)
    {
        if (state == instance.State_Glide || state == instance.State_SprintGlide)
        {
            if (!MoveInventory.Glide)
            {
                state = instance.State_Idle;
                return true;
            }
        }
        return false;
    }

    private static bool CancelFlutterStep(ref CharacterState state, ref BubsyCharacterController instance)
    {
        if (state == instance.State_FlutterJump)
        {
            if (!MoveInventory.FlutterStep)
            {
                state = instance.State_Idle;
                return true;
            }
        }
        return false;
    }

    private static bool PreventSkid(ref CharacterState state, ref BubsyCharacterController instance)
    {
        if (state == instance.State_Skid)
        {
            if (!MoveInventory.SkidJump)
            {
                Bubsy4DArchi.LogPatchMessage("Trying to prevent Skid from SAP");
                state = instance.State_Idle;
                return true;
            }
        }
        return false;
    }
}
