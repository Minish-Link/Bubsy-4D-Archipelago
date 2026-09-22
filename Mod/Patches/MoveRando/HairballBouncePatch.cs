
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "Hairball_ApplyBounceImpulse")]
public static class HairballBouncePatch
{
    public static bool Prefix()
    {
        if (!MoveInventory.HairballBounce)
        {
            MelonLogger.Msg("Trying to stop Hairball Bounce");
            return false;
        }
        return true;
    }
}