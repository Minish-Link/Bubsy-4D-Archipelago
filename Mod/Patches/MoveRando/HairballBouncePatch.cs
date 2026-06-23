
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "Hairball_ApplyBounceImpulse")]
public static class HairballBouncePatch
{
    public static bool Prefix()
    {
        if (!MoveInventory.HairballBounce)
        {
            Bubsy4DArchi.LogPatchMessage("Trying to stop Hairball Bounce");
            return false;
        }
        return true;
    }
}