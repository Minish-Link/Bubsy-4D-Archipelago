/*
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using UnityEngine;

namespace BubsyArchipelagoMod.Helpers;

public static class ValidStateHelper
{
    public static bool StateIsValid(CharacterState state, BubsyCharacterController bubsyInstance)
    {
        bool validState = true;
        if (!MoveInventory.Jump && state == bubsyInstance.State_Jump1)
        {
            Bubsy4DArchi.LogPatchMessage("Jump1 State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.DoubleJump && state == bubsyInstance.State_Jump2)
        {
            Bubsy4DArchi.LogPatchMessage("Jump2 State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.TripleJump && state == bubsyInstance.State_Jump3)
        {
            Bubsy4DArchi.LogPatchMessage("Jump3 State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.SkidJump && state == bubsyInstance.State_SkidJump)
        {
            Bubsy4DArchi.LogPatchMessage("Skid Jump State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.Pounce && state == bubsyInstance.State_Pounce)
        {
            Bubsy4DArchi.LogPatchMessage("Pounce State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.Pounce && state == bubsyInstance.State_SprintPounce)
        {
            Bubsy4DArchi.LogPatchMessage("Sprint Pounce State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.Glide && (state == bubsyInstance.State_Glide || state == bubsyInstance.State_SprintGlide || state == bubsyInstance.State_PounceGlideBrake))
        {
            Bubsy4DArchi.LogPatchMessage("Glide State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.FlutterStep && state == bubsyInstance.State_FlutterJump)
        {
            Bubsy4DArchi.LogPatchMessage("Flutter Jump state is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.WallCling && state == bubsyInstance.State_WallCling)
        {
            Bubsy4DArchi.LogPatchMessage("Wall Cling State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        else if (!MoveInventory.WallClimb && state == bubsyInstance.State_WallClimb)
        {
            Bubsy4DArchi.LogPatchMessage("Wall Climb State is not valid", LogType.MOVE_RANDO);
            validState = false;
        }
        return validState;
        
    }

    public static CharacterState GetReplacementState(CharacterState originalState, BubsyCharacterController bubsyInstance)
    {
        CharacterState newState = originalState;
        if (originalState == bubsyInstance.State_Jump2 && !MoveInventory.DoubleJump)
        {
            newState = bubsyInstance.State_Jump1;
        }
        if (originalState == bubsyInstance.State_Jump3 && !MoveInventory.TripleJump)
        {
            newState = bubsyInstance.State_Jump1;
        }
        if (originalState == bubsyInstance.State_SkidJump && !MoveInventory.SkidJump)
        {
            newState = bubsyInstance.State_Jump1;
        }
        if (originalState == bubsyInstance.State_Jump1 && !MoveInventory.Jump)
        {
            if (MoveInventory.DoubleJump)
            {
                newState = bubsyInstance.State_Jump2;
            }
            else if (MoveInventory.TripleJump)
            {
                newState = bubsyInstance.State_Jump3;
            }
        }

        return newState;
    }
}
*/