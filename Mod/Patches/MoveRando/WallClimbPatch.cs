using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;


namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BaseCharacterController), "CanAttachToWall")]
public static class WallAttachPatch
{
    public static bool Prefix()
    {
        return MoveInventory.WallCling;
    }
}

[HarmonyPatch(typeof(BubsyCharacterController), "TryWallClimbFromWall")]
public static class WallClimbPatch
{
    public static bool Prefix()
    {
        return true;
        //Bubsy4DArchi.LogPatchMessage("Trying to climb wall", LogType.MOVE_RANDO);
        //return false;
    }
}

[HarmonyPatch(typeof(BaseCharacterController), "TryWallCling")]
public static class WallClingPatch
{
    public static bool Prefix()
    {
        //return true;
        Bubsy4DArchi.LogPatchMessage("Trying to cling to wall", LogType.MOVE_RANDO);
        return MoveInventory.WallCling;
    }
}

[HarmonyPatch(typeof(BaseCharacterController), "TryWallFreeClimb")]
public static class WallFreeClimbPatch
{
    public static bool Postfix(ref CharacterState resultingState)
    {
        return true;
        //Bubsy4DArchi.LogPatchMessage(resultingState.ToString());
        //return false;
    }
}