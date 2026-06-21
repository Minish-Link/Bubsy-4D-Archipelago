
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;


namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "TryJump")]
public static class JumpPatch
{
    public static bool Prefix(bool jumpRequested)
    {
        if (jumpRequested && !MoveInventory.Jump)
        {
            Bubsy4DArchi.LogPatchMessage("Preventing jump");
            return false;
        }
        return true;
        // TODO
    }
}