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
        return MoveInventory.HairballState;
    }
}

[HarmonyPatch(typeof(ForceHairballState), "OnTriggerEnter")]
public static class ForcedHairballPatch
{
    public static bool Prefix()
    {
        return MoveInventory.HairballState;
    }
}