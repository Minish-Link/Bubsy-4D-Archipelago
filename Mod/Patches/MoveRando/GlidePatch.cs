using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "TryGlide")]
public static class GlidePatch
{
    public static bool Prefix()
    {
        return MoveInventory.Glide;
    }
}