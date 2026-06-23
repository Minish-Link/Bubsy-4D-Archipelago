
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;


[HarmonyPatch(typeof(BubsyCharacterController), "TrySkid")]
public static class SkidPatch
{
    public static bool Prefix()
    {
        if (!MoveInventory.SkidJump)
        {
            Bubsy4DArchi.LogPatchMessage("Trying to prevent TrySkid");
            return false;
        }
        return true;
    }
}
