using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.Interactables.Atari;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "EnterHairballForm")]
public static class HairballFormPatch
{
    public static bool Prefix()
    {
        if (!MoveInventory.HairballState)
        {
            Bubsy4DArchi.LogPatchMessage("Trying to prevent Hairball Form", LogType.MOVE_RANDO);
            return false;
        }
        return true;
    }
}

[HarmonyPatch(typeof(ForceHairballState), "OnTriggerEnter")]
public static class ForcedHairballPath
{
    public static bool Prefix()
    {
        if (!MoveInventory.HairballState)
        {
            Bubsy4DArchi.LogPatchMessage("Trying to prevent forced Hairball form", LogType.MOVE_RANDO);
            return false;
        }
        return true;
    }
}